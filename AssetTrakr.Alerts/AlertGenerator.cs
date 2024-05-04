using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Models.System;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.Alerts
{
    public class AlertGenerator
    {

        internal DatabaseContext _dbContext;
        internal List<Alert> _alerts;
        internal DateOnly _currentDate;
        internal int _thresholdValue = 0;
        internal DateOnly _thresholdDate;
        internal List<SystemSetting> _alertPreferences;

        public AlertGenerator()
        {
            _dbContext ??= new();
            _alerts ??= [];

            _currentDate = DateOnly.FromDateTime(DateTime.Now);

            if(_dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.AlertThreshold)))
            {
                _thresholdValue = Convert.ToInt32(_dbContext.SystemSettings.Where(ss => ss.Name == nameof(SystemSettings.AlertThreshold)).Select(ss => ss.SettingValue).First());
            }

            _thresholdDate = _currentDate.AddDays(_thresholdValue);

            _alertPreferences ??= _dbContext.SystemSettings.Where(ss => ss.Description == "Alert").ToList();
        }

        /// <summary>
        /// Generates the System Alerts
        /// </summary>
        /// <returns>
        /// <see cref="List{Alert}"/> of alerts 
        /// </returns>
        public List<Alert> GetAlerts()
        {

            bool includeArchived = _dbContext.SystemSettings.WhereEnabled(nameof(SystemSettings.IncludeArchivedInAlerts));

            AssetAlerts(includeArchived);
            LicenseAlerts(includeArchived);
            ContractAlerts(includeArchived);

            return _alerts;
        }

        /// <summary>
        /// Generates the Alerts for Assets 
        /// </summary>
        internal void AssetAlerts(bool includeArchived)
        {
            var assets = _dbContext.Assets
                .Include(a => a.AssetPeriods)
                    .ThenInclude(ap => ap.Period)
                .Include(a => a.AssetAttachments)
                .Where(a => includeArchived || !a.IsArchived);

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.NoAssetsAdded)))
            {
                if (!assets.Any())
                {
                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Asset,
                        Description = "No assets added",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.AssetsWithoutWarranty)))
            {
                if (assets.Any(a => a.IsUnderWarranty == false))
                {
                    int count = assets.Count(a => a.IsUnderWarranty == false);
                    string text = (count < 2) ? "asset" : "assets";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Asset,
                        Description = $"{count} {text} without warranty",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.AssetsWithExpiredWarranty)))
            {
                var assetsWithExpiredWarranty = assets
                    .Where(a => a.AssetPeriods.All(ap => ap.Period.EndDate < _currentDate));

                if (assetsWithExpiredWarranty.Any())
                {
                    int count = assetsWithExpiredWarranty.Count();
                    string text = (count == 1) ? "asset's warranty has" : "assets' warranties have";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Asset,
                        Description = $"{count} {text} expired",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.AssetsWithWarrantyExpiringSoon)))
            {
                var assetsWithExpiringWarranties = assets
                        .Where(a => a.AssetPeriods.Any(ap => ap.Period.EndDate >= _currentDate && ap.Period.EndDate <= _thresholdDate));

                if (assetsWithExpiringWarranties.Any())
                {
                    int count = assetsWithExpiringWarranties.Count();
                    string text = (count == 1) ? "asset has" : "assets have";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Asset,
                        Description = $"{count} {text} warranties expiring within the next {_thresholdValue} days",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.AssetsWithoutWarranty)))
            {
                if (assets.Any(a => a.AssetAttachments.Count == 0))
                {
                    int count = assets.Count(l => l.AssetAttachments.Count == 0);
                    string text = (count < 2) ? "asset" : "assets'";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Asset,
                        Description = $"{count} {text} without attachments",
                        Severity = Severity.Medium
                    });
                }
            }
        }

        /// <summary>
        /// Generates the alerts for Licenses
        /// </summary>
        internal void LicenseAlerts(bool includeArchived)
        {
            var licenses = _dbContext.Licenses
                .Include(l => l.LicensePeriods)
                    .ThenInclude(lp => lp.Period)
                .Where(l => includeArchived || !l.IsArchived);


            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.NoLicensesAdded)))
            {
                if (!licenses.Any())
                {
                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.License,
                        Description = "No licenses added",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.LicensesWithExpiredSubscriptions)))
            {
                var licensesWithExpiredSubscriptions = licenses
                    .Where(l => l.IsSubscription && l.LicensePeriods.All(lp => lp.Period.EndDate < _currentDate));

                if (licensesWithExpiredSubscriptions.Any())
                {
                    int count = licensesWithExpiredSubscriptions.Count();
                    string text = (count == 1) ? "license's subscription has" : "licenses' subscriptions have";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.License,
                        Description = $"{count} {text} expired",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.LicensesWithSubscriptionsExpiringSoon)))
            {
                var licensesWithExpiringWarranties = licenses
                    .Where(a => a.LicensePeriods.Any(ap => ap.Period.EndDate >= _currentDate && ap.Period.EndDate <= _thresholdDate));

                if (licensesWithExpiringWarranties.Any())
                {
                    int count = licensesWithExpiringWarranties.Count();
                    string text = (count == 1) ? "license has" : "licenses have";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.License,
                        Description = $"{count} {text} subscriptions expiring within the next {_thresholdValue} days",
                        Severity = Severity.High
                    });
                }
            }

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.LicensesWithoutAttachments)))
            {
                if (licenses.Any(l => l.LicenseAttachments.Count == 0))
                {
                    int count = licenses.Count(l => l.LicenseAttachments.Count == 0);
                    string text = (count < 2) ? "license" : "licenses";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.License,
                        Description = $"{count} {text} without attachments",
                        Severity = Severity.Medium
                    });
                }
            }

        }

        /// <summary>
        /// Generate the alerts for Contracts
        /// </summary>
        internal void ContractAlerts(bool includeArchived)
        {
            var contracts = _dbContext.Contracts
                .Include(c => c.ContractPeriods)
                    .ThenInclude(cp => cp.Period)
                .Where(c => includeArchived || !c.IsArchived);

            if (_alertPreferences.WhereEnabled(nameof(SystemSettings.NoContractsAdded))) 
            {
                if (!contracts.Any())
                {
                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Contract,
                        Description = "No contracts added",
                        Severity = Severity.High
                    });
                }
            }

            if(_alertPreferences.WhereEnabled(nameof(SystemSettings.ContractsWithoutAttachments))) 
            {
                if (contracts.Any(l => l.ContractAttachments.Count == 0))
                {
                    int count = contracts.Count(l => l.ContractAttachments.Count == 0);
                    string text = (count < 2) ? "contract" : "contracts";

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.Contract,
                        Description = $"{count} {text} without attachments",
                        Severity = Severity.Medium
                    });
                }
            }

            if(_alertPreferences.WhereEnabled(nameof(SystemSettings.ContractsExpiringSoon))) 
            {
                var contractsWithExpiringWarranties = contracts
                    .Where(a => a.ContractPeriods.Any(ap => ap.Period.EndDate >= _currentDate && ap.Period.EndDate <= _thresholdDate));

                if (contractsWithExpiringWarranties.Any())
                {
                    int count = contractsWithExpiringWarranties.Count();
                    string text = (count == 1) ? "contract is" : "contracts are";

                    // 1 contract is expiring within the next x days
                    // 2 contracts are expiring within the next x days

                    _alerts.Add(new Alert
                    {
                        Category = ActionAlertCategory.License,
                        Description = $"{count} {text} expiring within the next {_thresholdValue} days",
                        Severity = Severity.High
                    });
                }
            }
        }

        internal bool SystemAlerts()
        {
            throw new NotImplementedException();
        }
    }
}

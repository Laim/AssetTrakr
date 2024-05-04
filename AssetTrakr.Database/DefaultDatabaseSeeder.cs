using AssetTrakr.Models;
using AssetTrakr.Models.System;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.Database
{
    /// <summary>
    /// Seeds the default data into the database
    /// </summary>
    public class DefaultDatabaseSeeder
    {
        private ModelBuilder _modelBuilder;

        public DefaultDatabaseSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder ??= modelBuilder;
        }
  
        public ModelBuilder Seed()
        {

            SystemSettings();
            UserSettings();
            AssetAlerts();
            LicenseAlerts();
            Reports();
            ContractAlerts();

            return _modelBuilder;
        }

        /// <summary>
        /// Creates Report Data in the Database
        /// </summary>
        internal void Reports()
        {
            _modelBuilder.Entity<Report>(e =>
            {
                e.HasData
                (
                    new Report
                    {
                        ReportId = 1,
                        ShortCode = "awow",
                        Name = "Assets without Warranty",
                        HasCriteria = false,
                        Description = "All assets without warranty assigned, does not include expired warranty.",
                        ParentType = ParentType.Asset,
                        IsUserVisible = false,
                    },
                    new Report
                    {
                        ReportId = 2,
                        ShortCode = "aot",
                        Name = "Assets of Type",
                        HasCriteria = true,
                        Description = "Shows all assets in the system of the chosen criteria type.",
                        ParentType = ParentType.Asset,
                        IsUserVisible = true,
                    },
                    new Report
                    {
                        ReportId = 3,
                        ShortCode = "awls",
                        Name = "Assets With Low Storage",
                        HasCriteria = true,
                        Description = "Shows assets in the system with storage lower than the chosen threshold criteria.",
                        ParentType = ParentType.Asset,
                        IsUserVisible = true,
                    },
                    new Report
                    {
                        ReportId = 4,
                        ShortCode = "aww",
                        Name = "Assets with Warranty",
                        HasCriteria = false,
                        Description = "Shows all assets in the system with warranty whether active or expired.",
                        ParentType = ParentType.Asset,
                        IsUserVisible = true
                    },
                    new Report
                    {
                        ReportId = 5,
                        ShortCode = "aawaf",
                        Name = "All Assets with All Fields",
                        HasCriteria = false,
                        Description = "Shows all assets in the system with all available fields.",
                        ParentType = ParentType.Asset,
                        IsUserVisible = false
                    },
                    new Report
                    {
                        ReportId = 6,
                        ShortCode = "alwaf",
                        Name = "All Licenses with All Fields",
                        HasCriteria = false,
                        Description = "Shows all licenses in the system with all available fields.",
                        ParentType = ParentType.License,
                        IsUserVisible = false
                    },
                    new Report
                    {
                        ReportId = 7,
                        ShortCode = "costAnal",
                        Name = "Cost Analysis",
                        HasCriteria = false,
                        Description = "Shows Cost of all Entities in the System",
                        ParentType = ParentType.Other,
                        IsUserVisible = true
                    }
                );
            });
        }

        /// <summary>
        /// Creates the System Settings for the overall Appliction
        /// </summary>
        internal void SystemSettings()
        {
            _modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasData
                (
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AlertThreshold),
                        Category = SystemSettingsCategory.Application,
                        Description = "How many days before something expires to notify the user. (0 if disabled)",
                        DefaultEnabled = true,
                        SettingParentType = "Alerts",
                        Enabled = true,
                        SettingValue = "30",
                        DefaultSettingValue = "30"
                    },
                    // TODO: Re-add this so CheckForUpdates can be used by the end user when Updates is added
                    //new SystemSetting
                    //{
                    //    Name = nameof(Utils.Enums.SystemSettings.CheckForUpdates),
                    //    Category = SystemSettingsCategory.Application,
                    //    Description = "Automatically check for Updates",
                    //    SettingValue = "stable",
                    //    DefaultSettingValue = "stable",
                    //    DefaultEnabled = true,
                    //    Enabled = true,
                    //    SettingParentType = "Updates",
                    //},
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AutomaticBackups),
                        Category = SystemSettingsCategory.Application,
                        Description = "Backup the database on application start.  Value dictacts amount of backups to keep.",
                        SettingValue = "3",
                        Enabled = true,
                        DefaultEnabled = true,
                        DefaultSettingValue = "3",
                        SettingParentType = "Database"
                    }
                );
            });
        }

        /// <summary>
        /// Creates the System Settings for User Preferences
        /// </summary>
        internal void UserSettings()
        {
            _modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasData
                (
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.IncludeArchivedInAlerts),
                        Category = SystemSettingsCategory.User,
                        Description = "Includes Archived Entities in Alerts",
                        SettingValue = null,
                        Enabled = true,
                        DefaultEnabled = true,
                        DefaultSettingValue = null,
                        SettingParentType = "Archive"
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.IncludeArchivedInWidgets),
                        Category = SystemSettingsCategory.User,
                        Description = "Includes Archived Entities in Widgets",
                        SettingValue = null,
                        Enabled = true,
                        DefaultEnabled = true,
                        DefaultSettingValue = null,
                        SettingParentType = "Archive"
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.IncludeArchivedInViewAll),
                        Category = SystemSettingsCategory.User,
                        Description = "Includes Archived Entities in View All pages",
                        SettingValue = null,
                        Enabled = true,
                        DefaultEnabled = true,
                        DefaultSettingValue = null,
                        SettingParentType = "Archive"
                    }
                );
            });
        }

        /// <summary>
        /// Creates the System Settings for Asset Alerts
        /// </summary>
        internal void AssetAlerts()
        {
            
            // Asset Alerts
            _modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasData
                (
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.NoAssetsAdded),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Assets",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AssetsWithoutWarranty),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Assets",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AssetsWithExpiredWarranty),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Assets",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AssetsWithWarrantyExpiringSoon),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Assets",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.AssetsWithoutAttachments),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Assets",
                        DefaultEnabled = true,
                        Enabled = true
                    }

                );
            });
        }

        /// <summary>
        /// Creates the System Settings for License Alerts
        /// </summary>
        internal void LicenseAlerts()
        {


            _modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasData
                (
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.NoLicensesAdded),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Licenses",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.LicensesWithExpiredSubscriptions),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Licenses",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.LicensesWithSubscriptionsExpiringSoon),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Licenses",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.LicensesWithoutAttachments),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Licenses",
                        DefaultEnabled = true,
                        Enabled = true
                    }

                );
            });
        }

        /// <summary>
        /// Creates the System Settings for Contract Alerts
        /// </summary>
        internal void ContractAlerts()
        {

            // Asset Alerts
            _modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasData
                (
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.NoContractsAdded),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Contracts",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.ContractsExpiringSoon),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Contracts",
                        DefaultEnabled = true,
                        Enabled = true
                    },
                    new SystemSetting
                    {
                        Name = nameof(Utils.Enums.SystemSettings.ContractsWithoutAttachments),
                        Category = SystemSettingsCategory.Alert,
                        Description = "Alert",
                        SettingParentType = "Contracts",
                        DefaultEnabled = true,
                        Enabled = true
                    }

                );
            });
        }
    }
}

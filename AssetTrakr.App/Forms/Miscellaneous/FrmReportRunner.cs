using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Models;
using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmReportRunner : Form
    {
        private DatabaseContext _dbContext;
        private List<int> _thresholdCriteria = [];
        private List<Report> reports;

        public FrmReportRunner()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
            reports ??= _dbContext.Reports.ToList();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbReports.DataSource = reports.Where(r => r.IsUserVisible).ToList();
            cmbReports.DisplayMember = nameof(Report.Name);
            cmbReports.ValueMember = nameof(Report.ReportId);

            // threshold criteria
            _thresholdCriteria.Add(30);
            _thresholdCriteria.Add(60);
            _thresholdCriteria.Add(120);
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            if (cmbReports.SelectedItem is not Report selectedReport)
            {
                return;
            }

            if (cmbCritera.SelectedItem is null && selectedReport.HasCriteria == true)
            {
                MessageBox.Show($"{selectedReport.Name} requires criteria.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (selectedReport.ShortCode)
            {
                case "awow":
                    AssetsWithWarranty(false);
                    break;
                case "aot":
                    if (Enum.TryParse(cmbCritera.SelectedItem?.ToString(), true, out AssetType type2))
                    {
                        AssetsOfType(type2);
                    }
                    break;
                case "awls":
                    AssetsWithStorageThreshold(Convert.ToInt32(cmbCritera.SelectedValue));
                    break;
                case "aww":
                    AssetsWithWarranty(true);
                    break;
                case "costAnal":
                    CostReport();
                    break;
                case "aawaf":
                    AssetsWithAllFields();
                    break;
            }
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cmb)
            {
                return;
            }

            dgvReportOutput.DataSource = null;

            if (cmb.SelectedItem is not Report selectedReport)
            {
                return;
            }

            lblDescription.Text = selectedReport.Description;

            // no point switching through this data since we can just the report property hasCriteria lol
            if(selectedReport.HasCriteria == false)
            {
                cmbCritera.Enabled = false;
                cmbCritera.DataSource = null;
                cmbCritera.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            switch (selectedReport.ShortCode)
            {
                case "aot":
                    cmbCritera.Enabled = true;
                    cmbCritera.DataSource = Enum.GetValues(typeof(AssetType));
                    cmbCritera.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;
                case "awls":
                    cmbCritera.Enabled = true;
                    cmbCritera.DataSource = _thresholdCriteria;
                    cmbCritera.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;
            }
        }

        #region Reports

        /// <summary>
        /// Returns a list of Assets that have Warranty in the system, does not care if expired or active or Assets without Warranty
        /// <para name="hasWarranty">
        /// true or false
        /// </para>
        /// </summary>
        private void AssetsWithWarranty(bool hasWarranty)
        {

            var report = _dbContext.Assets
                .Include(a => a.Hardware)
                .Include(a => a.AssetPeriods)
                .ThenInclude(ap => ap.Period)
                .Include(a => a.Manufacturer)
                .Include(a => a.Platform)
                .Include(a => a.OperatingSystem)
                .Select
                (
                    a => new
                    {
                        a.AssetId,
                        a.Name,
                        a.Description,
                        OperatingSystem = a.OperatingSystem.Name,
                        Type = a.Hardware.AssetType,
                        a.Model,
                        Platform = a.Platform.Name,
                        Manufacturer = a.Manufacturer.Name,
                        a.IsUnderWarranty,
                        a.PurchaseDate,
                        WarrantyPeriodsFormatted = string.Join($",{Environment.NewLine}", a.AssetPeriods
                            .Where(ap => ap != null && ap.Period != null)
                            .Select(ap => ap.Period.StartDate.ToString("d") + " - " + ap.Period.EndDate.ToString("d"))),
                    }
                )
                .Where(a => a.IsUnderWarranty == hasWarranty).ToBindingList();

            dgvReportOutput.DataSource = report;

            // set wrap mode for all of the columns
            foreach (DataGridViewColumn column in dgvReportOutput.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            // Hide the columns this way so the user can use the Column Selector
            // also rename them to be a bit nicer in the DGV
            dgvReportOutput.Columns["AssetId"].Visible = false;
            dgvReportOutput.Columns["IsUnderWarranty"].Visible = false;
            dgvReportOutput.Columns["WarrantyPeriodsFormatted"].HeaderText = "Warranty";
            dgvReportOutput.Columns["OperatingSystem"].HeaderText = "Operating System";
        }

        /// <summary>
        /// Returns a list of Assets in the system of a specific <see cref="AssetType"/>
        /// </summary>
        /// <param name="type">
        /// The specific type you want to find of <see cref="AssetType"/>
        /// </param>
        /// <returns>>
        /// </returns>
        private void AssetsOfType(AssetType type)
        {
            dgvReportOutput.DataSource = _dbContext.Assets
                .Include(a => a.Hardware)
                .Include(a => a.Manufacturer)
                .Include(a => a.Platform)
                .Include(a => a.OperatingSystem)
                .Select
                (
                    a => new
                    {
                        a.AssetId,
                        a.Name,
                        a.Description,
                        OperatingSystem = a.OperatingSystem.Name,
                        a.Hardware.AssetType,
                        a.Model,
                        Platform = a.Platform.Name,
                        Manufacturer = a.Manufacturer.Name,
                        a.IsUnderWarranty,
                        a.PurchaseDate,
                    }
                )
                .Where(a => a.AssetType == type).ToBindingList();

            // Hide the columns this way so the user can use the Column Selector
            // also rename them to be a bit nicer in the DGV
            dgvReportOutput.Columns["AssetId"].Visible = false;
            dgvReportOutput.Columns["AssetType"].HeaderText = "Type";
            dgvReportOutput.Columns["OperatingSystem"].HeaderText = "Operating System";
        }

        /// <summary>
        /// Returns a list of Assets in the system that have less storage than the configured threshold
        /// </summary>
        /// <returns>
        /// </returns>
        private void AssetsWithStorageThreshold(int storageThreshold)
        {

            var excludedTypes = new[] { AssetType.Monitor, AssetType.Peripherals, AssetType.Other };

            dgvReportOutput.DataSource = _dbContext.Assets
                .Include(a => a.Hardware)
                .ThenInclude(ah => ah.HardDrives)
                .Where(
                    a => a.Hardware.HardDrives.All(hd => hd.SizeInGB < storageThreshold)
                    && !excludedTypes.Contains(a.Hardware.AssetType)
                ).ToBindingList();

            // Hide the columns this way so the user can use the Column Selector
            dgvReportOutput.Columns[nameof(Models.Assets.Asset.AssetId)].Visible = false;
        }
        
        /// <summary>
        /// Returns list of all assets in the system with all fields
        /// </summary>
        private void AssetsWithAllFields()
        {
            dgvReportOutput.DataSource = _dbContext.Assets
                .Include(a => a.Manufacturer)
                .Include(a => a.Contract)
                    .ThenInclude(ac => ac.ContractPeriods)
                .Include(a => a.AssetAttachments)
                .Include(a => a.Platform)
                .Include(a => a.AssetPeriods)
                    .ThenInclude(p => p.Period)
                .Include(ah => ah.Hardware)
                    .ThenInclude(ah => ah.HardDrives)
                .Include(ah => ah.Hardware)
                    .ThenInclude(ah => ah.NetworkAdapters)
                .ToList();

            // Hide the columns this way so the user can use the Column Selector
            dgvReportOutput.Columns[nameof(Models.Assets.Asset.AssetId)].Visible = false;
        }

        /// <summary>
        /// Shows a report on costs spend 
        /// </summary>
        private void CostReport()
        {
            // ideal layout
            // entityType | paymentFreq | cost
            // ie:
            // Contracts | Monthly | 199.34
            // Contracts | Yearly  | 3,493.23
            // Licenses  | Once    | 2,500
            // Licenses  | Monthly | 19.99

            var contractQuery = _dbContext.Contracts
                .ToList() // Fetch the data to perform aggregation in-memory
                .GroupBy(c => c.PaymentFrequency)
                .Select(g => new
                {
                    Entity = "Contracts",
                    PaymentFrequency = g.Key,
                    TotalCost = g.Sum(c => c.Price)
                });

            var licenseQuery = _dbContext.Licenses
                .ToList() // Fetch the data to perform aggregation in-memory
                .GroupBy(l => l.PaymentFrequency)
                .Select(g => new
                {
                    Entity = "Licenses",
                    PaymentFrequency = g.Key,
                    TotalCost = g.Sum(l => l.Price)
                });

            var assetQuery = _dbContext.Assets
                .ToList() // Fetch the data to perform aggregation in-memory
                .GroupBy(l => "Once")
                .Select(g => new
                {
                    Entity = "Assets",
                    PaymentFrequency = g.Key,
                    TotalCost = g.Sum(l => l.Price)
                });

            var reportData = contractQuery
            .Select(q => new PaymentSummary { Entity = q.Entity, PaymentFrequency = q.PaymentFrequency.ToString(), TotalCost = q.TotalCost })
                .Concat(licenseQuery.Select(q => new PaymentSummary { Entity = q.Entity, PaymentFrequency = q.PaymentFrequency.ToString(), TotalCost = q.TotalCost }))
                .Concat(assetQuery.Select(q => new PaymentSummary { Entity = q.Entity, PaymentFrequency = q.PaymentFrequency, TotalCost = q.TotalCost }))
            .ToList();

            DataTable dataTable = new();
            dataTable.Columns.Add("Entity");
            dataTable.Columns.Add("Payment Frequency");
            dataTable.Columns.Add("Total Cost", typeof(decimal));

            foreach(var item in reportData)
            {
                dataTable.Rows.Add(item.Entity, item.PaymentFrequency, item.TotalCost);
            }

            dgvReportOutput.DataSource = dataTable;

        }

        #endregion

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmColumnSelector2 frmColumnSelector = new(dgv);
                frmColumnSelector.ShowDialog();

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.Visible = frmColumnSelector.SelectedColumns.Contains(col.Name);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvReportOutput.Export();
        }
    }
}

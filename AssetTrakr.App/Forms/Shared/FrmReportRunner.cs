using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using AssetTrakr.Utils.Enums;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            cmbReports.DataSource = reports;
            cmbReports.DisplayMember = "Name";
            cmbReports.ValueMember = "ReportId";

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


        /// <summary>
        /// Returns a list of Assets that have Warranty in the system, does not care if expired or active
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
            dgvReportOutput.DataSource = _dbContext.Assets
                .Include(a => a.Hardware)
                .ThenInclude(ah => ah.HardDrives)
                .Where(a => a.Hardware.HardDrives.All(hd => hd.SizeInGB < storageThreshold)).ToBindingList();

            // Hide the columns this way so the user can use the Column Selector
            dgvReportOutput.Columns["AssetId"].Visible = false;
        }

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

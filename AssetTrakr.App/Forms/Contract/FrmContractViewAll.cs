using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Extensions;

namespace AssetTrakr.App.Forms.Contract
{
    public partial class FrmContractViewAll : Form
    {
        private readonly DatabaseContext _dbContext;

        public FrmContractViewAll()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadData();
        }

        /// <summary>
        /// Loads all of the Contracts data into the DataGridView
        /// </summary>
        /// <param name="needReload">
        /// True or False, true resets the datasource to NULL before loading data
        /// </param>
        private void LoadData(bool needReload = false)
        {
            if (needReload)
            {
                dgvViewAll.DataSource = null;
            }

            dgvViewAll.Visible = true;
            lblNoContractsDescription.Visible = false;
            lblNoContractsTitle.Visible = false;

            var contracts = _dbContext.Contracts.ToList();

            dgvViewAll.DataSource = contracts;

            // Rename columns since it's an anonymous type and ignores [DisplayName] attribute in the License model
            dgvViewAll.Columns[nameof(Models.Contract.OrderRef)].HeaderText = "Order Reference";
            dgvViewAll.Columns[nameof(Models.Contract.PaymentFrequency)].HeaderText = "Pay Frequency";

            // hide columns
            dgvViewAll.Columns[nameof(Models.Contract.ContractId)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.CreatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.UpdatedDate)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.UpdatedBy)].Visible = false;
            dgvViewAll.Columns[nameof(Models.Contract.CreatedBy)].Visible = false;

            if (!contracts.Any())
            {
                dgvViewAll.Visible = false;
                lblNoContractsDescription.Visible = true;
                lblNoContractsTitle.Visible = true;
            }
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
            dgvViewAll.Export();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmContractModify frmContractModify = new(contractId: (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value);
                frmContractModify.ShowDialog();
                LoadData(true);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmContractModify frmContractModify = new(contractId: (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value, isReadOnly: true);
                frmContractModify.ShowDialog();
            }
        }
    }
}

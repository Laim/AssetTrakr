using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    public partial class FrmActionLog : Form
    {

        private readonly DatabaseContext _dbContext;

        public FrmActionLog()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dgvActionLog.DataSource = _dbContext.ActionLogEntries
                .OrderByDescending(ale => ale.ActionId)
                .ToBindingList();

            dgvActionLog.Columns["ActionId"].Visible = false;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext.Dispose();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvActionLog.Export();
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
    }
}

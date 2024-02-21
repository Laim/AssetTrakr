using AssetTrakr.Database;
using AssetTrakr.Models.Extensions;
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
    }
}

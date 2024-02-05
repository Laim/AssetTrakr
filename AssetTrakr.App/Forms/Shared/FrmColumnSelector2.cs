
namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmColumnSelector2 : Form
    {
        public List<string> AvailableColumns = [];
        public List<string> SelectedColumns = [];

        public FrmColumnSelector2(DataGridView dgv)
        {
            InitializeComponent();

            if(dgv == null)
            {
                throw new ArgumentOutOfRangeException(nameof(dgv), "DataGridView has not been passed to form");
            }

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    SelectedColumns.Add(col.Name);
                }
                else
                {
                    AvailableColumns.Add(col.Name);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string column in AvailableColumns)
            {
                if(!column.EndsWith("Id"))
                {
                    chkLbColumns.Items.Add(column);
                }
            }

            foreach (string column in SelectedColumns)
            {
                chkLbColumns.Items.Add(column);
                // minus one to prevent index outta range
                chkLbColumns.SetItemChecked(chkLbColumns.Items.Count - 1, true);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            AvailableColumns.Clear();
            SelectedColumns.Clear();

            foreach(string column in chkLbColumns.Items)
            {
                var colIndex = chkLbColumns.FindStringExact(column);

                if(chkLbColumns.GetItemChecked(colIndex))
                {
                    SelectedColumns.Add(column);
                } 

                AvailableColumns.Add(column);
            }
        }
    }
}

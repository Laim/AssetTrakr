namespace AssetTrakr.App.Forms.Shared
{
    [Obsolete("FrmColumnSelector2 is better, this will never be updated.")]
    public partial class FrmColumnSelector : Form
    {
        public List<string> AvailableColumns = [];
        public List<string> SelectedColumns = [];

        public FrmColumnSelector(DataGridView dgv)
        {
            InitializeComponent();

            if (dgv == null)
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

            foreach (string column in SelectedColumns)
            {
                lbSelectedColumns.Items.Add(column);
            }

            List<string> columnsToHide = ["AssetHardware", "Manufacturer"];

            foreach (string column in AvailableColumns)
            {
                if (!column.EndsWith("Id")) // Hide the Id columns, user doesn't need them
                {
                    if (columnsToHide.Contains(column))
                    {
                        continue;
                    }

                    lbAvailableColumns.Items.Add(column);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            AvailableColumns.Clear();
            SelectedColumns.Clear();

            foreach(string item in lbAvailableColumns.Items)
            {
                AvailableColumns.Add(item);
            }

            foreach(string item in lbSelectedColumns.Items)
            {
                SelectedColumns.Add(item);
            }
        }
        private void btnAddToSelected_Click(object sender, EventArgs e)
        {
            if (lbAvailableColumns.SelectedItem != null)
            {
                var selectedRow = lbAvailableColumns.SelectedItem as string;

                lbAvailableColumns.Items.Remove(selectedRow);

                lbSelectedColumns.Items.Add(selectedRow);
            }
        }

        private void btnRemoveFromSelected_Click(object sender, EventArgs e)
        {
            if(lbSelectedColumns.SelectedItem != null)
            {
                var selectedRow = lbSelectedColumns.SelectedItem as string;

                lbSelectedColumns.Items.Remove(selectedRow);

                lbAvailableColumns.Items.Add(selectedRow);
            }
        }
    }
}

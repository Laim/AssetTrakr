namespace AssetTrakr.App.Forms.Shared
{
    [Obsolete("Use FrmColumnSelector2 instead", true)]
    public partial class FrmColumnSelector : Form
    {
        public List<string> AvailableColumns;
        public List<string> SelectedColumns;

        public FrmColumnSelector(List<string> availableColumns, List<string> selectedColumns)
        {
            InitializeComponent();

            AvailableColumns ??= availableColumns;

            SelectedColumns ??= selectedColumns;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string column in AvailableColumns)
            {
                lbAvailableColumns.Items.Add(column);
            }

            foreach (string column in SelectedColumns)
            {
                lbSelectedColumns.Items.Add(column);
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

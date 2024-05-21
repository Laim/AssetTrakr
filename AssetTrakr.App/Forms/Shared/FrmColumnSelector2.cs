
using Syncfusion.WinForms.DataGrid;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmColumnSelector2 : Form
    {
        public List<string> AvailableColumns = [];
        public List<string> SelectedColumns = [];

        public FrmColumnSelector2(DataGridView? dgv2 = null, SfDataGrid? sfDgv = null)
        {
            InitializeComponent();

            if(sfDgv == null)
            {
                throw new ArgumentOutOfRangeException(nameof(sfDgv), "Data Grid has not been passed to form");
            }

            foreach (var col in sfDgv.Columns)
            {
                if (col.Visible)
                {
                    SelectedColumns.Add(col.MappingName);
                }
                else
                {
                    AvailableColumns.Add(col.MappingName);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string column in SelectedColumns)
            {
                chkLbColumns.Items.Add(column);
                // minus one to prevent index outta range
                chkLbColumns.SetItemChecked(chkLbColumns.Items.Count - 1, true);
            }

            List<string> columnsToHide = ["AssetHardware", "Manufacturer"];

            foreach (string column in AvailableColumns)
            {
                if(!column.EndsWith("Id")) // Hide the Id columns, user doesn't need them
                {
                    if (columnsToHide.Contains(column))
                    { 
                        continue; 
                    }

                    chkLbColumns.Items.Add(column);
                }
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

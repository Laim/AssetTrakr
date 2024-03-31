using AssetTrakr.Logging;
using OfficeOpenXml;

namespace AssetTrakr.Extensions
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Exports current DataGridView visible contents to .xlsx using <see cref="ExcelPackage"/>
        /// </summary>
        /// <param name="dgv">
        /// The current <see cref="DataGridView"/>
        /// </param>
        public static void Export(this DataGridView dgv)
        {
            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = true,
                Filter = "Excel Files|*.xlsx",
                Title = "Save Export",
                FileName = $"{Guid.NewGuid()}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var package = new ExcelPackage(new FileInfo(saveFileDialog.FileName));
                    var worksheet = package.Workbook.Worksheets.Add("Report");

                    // Get visible columns in the current display order
                    var visibleColumns = dgv.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .OrderBy(c => c.DisplayIndex);

                    // Write column headers
                    int columnIndex = 1;
                    foreach (var column in visibleColumns)
                    {
                        worksheet.Cells[1, columnIndex].Value = column.HeaderText;
                        columnIndex++;
                    }

                    // Write data
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        int cellIndex = 1;
                        foreach (var column in visibleColumns)
                        {
                            worksheet.Cells[i + 2, cellIndex].Value = dgv.Rows[i].Cells[column.Index].Value;
                            cellIndex++;
                        }
                    }

                    package.Save();
                } catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.Error($"{ex}", nameof(DataGridViewExtensions));
                }
            }

        }
    }
}

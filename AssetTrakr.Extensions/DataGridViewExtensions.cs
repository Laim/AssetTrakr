using AssetTrakr.Logging;
using OfficeOpenXml;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.XlsIO;
using System.Data;

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

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Export Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                MessageBox.Show($"Export saved to {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error($"{ex}", typeof(DataGridViewExtensions));
            }

        }

        /// <summary>
        /// Exports current SfDataGrid visible contents to .xlsx using <see cref="ExcelEngine"/>
        /// </summary>
        /// <param name="sfDataGrid">
        /// The current <see cref="SfDataGrid"/>
        /// </param>
        public static void Export(this SfDataGrid sfDataGrid)
        {
            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = true,
                Filter = "Excel Files|*.xlsx",
                Title = "Save Export",
                FileName = $"{Guid.NewGuid()}.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Export Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IWorkbook workbook = excelEngine.Excel.Workbooks.Create();
                    IWorksheet worksheet = workbook.Worksheets[0];

                    // Write column headers
                    int columnIndex = 1;
                    foreach (var column in sfDataGrid.Columns)
                    {
                        if (column.Visible)
                        {
                            worksheet[1, columnIndex].Text = column.HeaderText;
                            columnIndex++;
                        }
                    }

                    // Write data
                    var dataSource = sfDataGrid.DataSource as IEnumerable<dynamic>;
                    if (dataSource != null)
                    {
                        int rowIndex = 2;
                        foreach (var item in dataSource)
                        {
                            int cellIndex = 1;
                            foreach (var column in sfDataGrid.Columns)
                            {
                                if (column.Visible)
                                {
                                    var property = item.GetType().GetProperty(column.MappingName);
                                    if (property != null)
                                    {
                                        var value = property.GetValue(item);
                                        worksheet[rowIndex, cellIndex].Text = value?.ToString();
                                    }
                                    cellIndex++;
                                }
                            }
                            rowIndex++;
                        }
                    }

                    workbook.SaveAs(saveFileDialog.FileName);

                    MessageBox.Show($"Export saved to {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error($"{ex}", typeof(DataGridViewExtensions));
            }
        }
    }
}

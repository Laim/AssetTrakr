using AssetTrakr.Database;
using AssetTrakr.Logging;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SQLitePCL;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.XlsIO;
using System.Data;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace AssetTrakr.Extensions
{
    [SupportedOSPlatform("windows")]
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
                using (ExcelEngine excelEngine = new())
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

        /// <summary>
        /// Get's a property from the CurrentItem's model using .CurrentItem.GetType()
        /// </summary>
        /// <param name="sfDataGrid">
        /// The current <see cref="SfDataGrid"/>
        /// </param>
        public static T? GetCurrentItemProperty<T>(this SfDataGrid sfDataGrid, string propertyName, DatabaseContext dbContext) where T : class
        {
            if (sfDataGrid.CurrentItem == null)
            {
                LogManager.Fatal("Unable to pull property using Reflection! CurrentItem is null.", typeof(DataGridViewExtensions));
                return null;
            }

            var type = sfDataGrid.CurrentItem.GetType();

            object? propertyValue = type.GetProperty(propertyName)?.GetValue(sfDataGrid.CurrentItem, null);

            if(propertyValue == null)
            {
                LogManager.Fatal($"Unable to pull {propertyName} using Reflection!", typeof(DataGridViewExtensions));
                return null;
            }

            return dbContext.Set<T>().FirstOrDefault(e => EF.Property<object>(e, propertyName).Equals(propertyValue));

        }

        /// <summary>
        /// Loops through the <see cref="SfDataGrid"/> and changes the column header text using <see cref="StringToPropertyExtensions.GetPropertyDisplayName{T}(string)"/>
        /// and the column visibility using <see cref="StringToPropertyExtensions.GetPropertyVisibility{T}(string)"/>.  Also changes the Archived column visibility
        /// based on <paramref name="includeArchived"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The base model for DataGrid
        /// </typeparam>
        /// <param name="sfDataGrid">
        /// The current <see cref="SfDataGrid"/>
        /// </param>
        /// <param name="includeArchived">
        /// User System Setting which is true or false for including archived items in the sfDataGrid or not
        /// </param>
        public static void CustomColumnModifier<T>(this SfDataGrid sfDataGrid, bool includeArchived) where T : class
        {
            // hide non-default columns
            if (sfDataGrid.Columns.Count == 0)
            {
                return;
            }

            // rename the columns to their respective DisplayName value from the model
            // the efcore result is an anonymous object so we gotta do this
            foreach (var column in sfDataGrid.Columns)
            {
                // Get the property name from the column
                string propertyName = column.MappingName;


                // Set the header text of the column to the display name and column visibility
                column.HeaderText = propertyName.GetPropertyDisplayName<T>();
                column.Visible = propertyName.GetPropertyVisibility<T>();
            }

            // show the archive column if the system setting is enabled
            if (includeArchived)
            {
                try
                {
                    sfDataGrid.Columns["IsArchived"].Visible = true;
                }
                catch
                {
                    LogManager.Fatal($"Unable to modify IsArchived visibility, is the column name correct in {typeof(T)}?", typeof(DataGridViewExtensions));
                }
            }
        }
    }
}

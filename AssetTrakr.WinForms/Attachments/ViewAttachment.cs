using AssetTrakr.Logging;
using AssetTrakr.Utils.Enums;
using System.Diagnostics;

namespace AssetTrakr.WinForms.Attachments
{
    public class ViewAttachment
    {
        public void View(ContextMenuStrip cms, DataGridView dgvAttachments)
        {
            if (cms.SourceControl is not DataGridView dgv || dgv.Rows.Count == 0)
            {
                return;
            }

            // this should never actually happen since view is only enabled on cms show if the dgv is dgvAttachments, but alas
            if (dgv.Name != nameof(dgvAttachments))
            {
                return;
            }

            var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

            if (dataItem is not Models.Attachment attachment)
            {
                return;
            }

            if (attachment.Type == AttachmentType.Url)
            {

                DialogResult dr = MessageBox.Show($"Do you wish to go to {attachment.Url}?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    Process.Start(
                        new ProcessStartInfo($"{attachment.Url}")
                        {
                            UseShellExecute = true
                        }
                    );
                }
                return;
            }

            if (attachment.Type == AttachmentType.File)
            {
                DialogResult dr = MessageBox.Show($"Do you wish to download and open {attachment.Name}{attachment.DataType}?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    string filePath = Path.Combine(Path.GetTempPath(), $"{attachment.Name}{attachment.DataType}");

                    try
                    {
                        File.WriteAllBytes(filePath, attachment.Data);

                        Process.Start(
                            new ProcessStartInfo($"{filePath}")
                            {
                                UseShellExecute = true
                            }
                        );

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.Error<ViewAttachment>($"{ex}");
                    }
                }
            }
        }
    }
}

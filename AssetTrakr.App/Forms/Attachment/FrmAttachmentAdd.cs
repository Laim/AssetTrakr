using AssetTrakr.Utils.Enums;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Attachment
{
    public partial class FrmAttachmentAdd : Form
    {
        public BindingList<Models.Attachment> Attachments;

        public FrmAttachmentAdd(BindingList<Models.Attachment> attachments)
        {
            InitializeComponent();

            Attachments ??= [];

            // To account for previously added and prevent data loss on user end
            if (attachments != null)
            {
                Attachments = attachments;
            }
        }

        private void cbIsUrl_CheckedChanged(object sender, EventArgs e)
        {
            gbAttachmentFile.Enabled = !cbIsUrl.Checked;
            gbAttachmentUrl.Enabled = cbIsUrl.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            // throw error if file path is empty but url is not selected
            if (!cbIsUrl.Checked && txtAttachmentFilePath.Text.Length == 0)
            {
                MessageBox.Show("Attachment File Path has not been entered", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if the file selected exists
            if (!cbIsUrl.Checked)
            {
                if (!File.Exists(txtAttachmentFilePath.Text))
                {
                    MessageBox.Show("The file choosen does not exist or cannot be accessed", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            byte[] fileData = [];
            var attachmentUrl = string.Empty;
            AttachmentType attachmentType;

            // The idea here is that you cannot add a URL and a file as a single attachment
            if (cbIsUrl.Checked)
            {
                attachmentUrl = txtAttachmentUrl.Text;
                attachmentType = AttachmentType.Url;
            }
            else
            {
                fileData = File.ReadAllBytes(txtAttachmentFilePath.Text);
                attachmentType = AttachmentType.File;
            }

            Attachments.Add(new Models.Attachment
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Data = fileData,
                DataType = Path.GetExtension(txtAttachmentFilePath.Text),
                IsUrl = cbIsUrl.Checked,
                Type = attachmentType,
                Url = attachmentUrl
            });

            MessageBox.Show($"Attachment '{txtName.Text}' added", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAttachmentFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "All files (*.*)|*.*",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                ValidateNames = true,
                AddExtension = true,
                ShowHiddenFiles = false,
                ShowPreview = true
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtAttachmentFilePath.Text = dialog.FileName;
            }
        }
    }
}

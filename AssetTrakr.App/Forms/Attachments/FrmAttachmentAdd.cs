using AssetTrakr.Database;
using AssetTrakr.Models.Enums;

namespace AssetTrakr.App.Forms.Attachments
{
    public partial class FrmAttachmentAdd : Form
    {
        public readonly DatabaseContext _dbContext;

        public List<int> AttachmentIds;

        public FrmAttachmentAdd(DatabaseContext DbContext, List<int> AttachIds)
        {
            InitializeComponent();

            _dbContext ??= DbContext;

            AttachmentIds ??= [];

            // To account for previously added and prevent data loss on user end
            if (AttachIds != null)
            {
                AttachmentIds = AttachIds;
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

            var entry = new Models.Attachment
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Data = fileData,
                DataType = Path.GetExtension(txtAttachmentFilePath.Text),
                IsUrl = cbIsUrl.Checked,
                Type = attachmentType,
                Url = attachmentUrl
            };

            _dbContext.Add(entry);

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AttachmentIds.Add(entry.AttachmentId);
            }
            else
            {
                MessageBox.Show($"{txtName.Text} was not added successfully", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

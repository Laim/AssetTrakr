using AssetTrakr.App.Forms.Attachments;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.Database;
using AssetTrakr.Models.Extensions;

namespace AssetTrakr.App.Forms.Contract
{
    public partial class FrmContractAdd : Form
    {
        private readonly DatabaseContext _dbContext;
        private List<int> _attachmentIds = [];
        private List<int> _subscriptionPeriodIds = [];

        public FrmContractAdd(DatabaseContext DbContext)
        {
            InitializeComponent();

            _dbContext ??= DbContext;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 150)
            {
                MessageBox.Show("Name must be be less than 151 characters", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Name is a required field", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtOrderRef.Text.Length > 150)
            {
                MessageBox.Show("Order Ref must be less than 151 characters", "Order Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtOrderRef.Text.Length == 0)
            {
                MessageBox.Show("Order Ref is a required field", "Order Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if they already exist
            var t = _dbContext.Contracts
                .Select(x => x)
                .Where(x => x.Name == txtName.Text || x.OrderRef == txtOrderRef.Text).FirstOrDefault();

            if (t == null)
            {
                _dbContext.Add(new Models.Contract
                {
                    Name = txtName.Text,
                    OrderRef = txtOrderRef.Text,
                    Description = txtDescription.Text,
                    AttachmentIds = _attachmentIds,
                    SubscriptionIds = _subscriptionPeriodIds,
                });

                if (_dbContext.SaveChanges() > 0)
                {
                    MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Name and Order Ref must be UNIQUE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSubPeriod_Click(object sender, EventArgs e)
        {
            FrmSubscriptionPeriodAdd frmSubscriptionPeriodAdd = new(_dbContext, _subscriptionPeriodIds);
            frmSubscriptionPeriodAdd.ShowDialog();

            if (frmSubscriptionPeriodAdd.PeriodIds != null && frmSubscriptionPeriodAdd.PeriodIds.Count > 0)
            {
                _subscriptionPeriodIds = frmSubscriptionPeriodAdd.PeriodIds;

                dgvPeriods.DataSource = _dbContext.Periods
                    .Where(l => _subscriptionPeriodIds.Contains(l.Id))
                    .ToModelSubscriptionPeriod();

                // Hide the non-default columns from the end user
                dgvPeriods.Columns["Id"].Visible = false;
                dgvPeriods.Columns["CreatedDate"].Visible = false;
                dgvPeriods.Columns["UpdatedDate"].Visible = false;
                dgvPeriods.Columns["CreatedBy"].Visible = false;
                dgvPeriods.Columns["UpdatedBy"].Visible = false;
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            FrmAttachmentAdd frmAttachmentAdd = new(_dbContext, _attachmentIds);
            frmAttachmentAdd.ShowDialog();

            if (frmAttachmentAdd.AttachmentIds != null && frmAttachmentAdd.AttachmentIds.Count > 0)
            {
                _attachmentIds = frmAttachmentAdd.AttachmentIds;

                dgvAttachments.DataSource = _dbContext.Attachments
                    .Where(l => _attachmentIds.Contains(l.AttachmentId))
                    .ToModelAttachment();

                // Hide the non-default columns from the end user
                dgvAttachments.Columns["Id"].Visible = false;
                dgvAttachments.Columns["Data"].Visible = false;
                dgvAttachments.Columns["DataType"].Visible = false;
                dgvAttachments.Columns["Url"].Visible = false;
                dgvAttachments.Columns["IsUrl"].Visible = false;
                dgvAttachments.Columns["CreatedDate"].Visible = false;
                dgvAttachments.Columns["UpdatedDate"].Visible = false;
                dgvAttachments.Columns["CreatedBy"].Visible = false;
                dgvAttachments.Columns["UpdatedBy"].Visible = false;
            }
        }

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                FrmColumnSelector2 frmColumnSelector = new(dgv);
                frmColumnSelector.ShowDialog();

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.Visible = frmColumnSelector.SelectedColumns.Contains(col.Name);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is DataGridView dgv)
            {
                if (dgv.Rows.Count == 0)
                {
                    return;
                }

                int selectedId = (int)dgv.Rows[dgv.SelectedRows[0].Index].Cells["Id"].Value;

                if (dgv.Name == nameof(dgvAttachments))
                {
                    var att = _dbContext.Attachments.SingleOrDefault(x => x.AttachmentId == selectedId);

                    if(att != null)
                    {
                        _dbContext.Attachments.Remove(att);
                        _attachmentIds.Remove(selectedId);
                    }
                    else
                    {
                        throw new Exception("Attachment has not been set or cannot be found");
                    }
                }
                else if (dgv.Name == nameof(dgvPeriods))
                {
                    var period = _dbContext.Periods.SingleOrDefault(x => x.Id == selectedId);

                    if(period != null)
                    {
                        _dbContext.Periods.Remove(period);
                        _subscriptionPeriodIds.Remove(selectedId);
                    } else
                    {
                        throw new Exception("Period has not been set or cannot be found");
                    }
                }

                if (_dbContext.SaveChanges() > 0)
                {
                    foreach (DataGridViewRow item in dgv.SelectedRows)
                    {
                        dgv.Rows.RemoveAt(item.Index);
                    }
                }

                if (dgv.Rows.Count == 0)
                {
                    dgv.DataSource = null;
                }
            }
        }
    }
}

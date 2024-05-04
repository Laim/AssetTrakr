using AssetTrakr.App.Forms.Attachment;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Extensions;
using AssetTrakr.Logging;
using AssetTrakr.Models;
using AssetTrakr.Utils.Enums;
using AssetTrakr.WinForms.ActionLog;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Contract
{
    public partial class FrmContractModify : Form
    {
        private readonly DatabaseContext _dbContext;
        private BindingList<Models.Attachment> _attachments = [];
        private BindingList<Period> _periods = [];
        private readonly bool _isEditingMode = false;
        private readonly Models.Contract? _contractData;
        private readonly bool _isReadOnly;

        public FrmContractModify(int contractId = 0, bool isReadOnly = false)
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

            _isReadOnly = isReadOnly;

            if (contractId <= 0)
            {
                return;
            }

            var contract = _dbContext.Contracts
                .Include(c => c.ContractAttachments)
                    .ThenInclude(ca => ca.Attachment)
                .Include(c => c.ContractPeriods)
                    .ThenInclude(cp => cp.Period)
                .FirstOrDefault(c => c.ContractId == contractId);

            if (contract != null && !isReadOnly)
            {
                _contractData = contract;
                _isEditingMode = true;

                // Update general form info
                btnAddUpdate.Text = "Update";
                Text = $"Modify Contract - {_contractData.Name}";
            }

            if (isReadOnly && contract != null)
            {
                _contractData = contract;
                Helpers.Utils.SetReadOnly(this, deleteToolStripMenuItem);
                Text = $"Viewing Contract - {_contractData.Name}";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbPaymentFrequency.DataSource = Enum.GetValues(typeof(PaymentFrequency));

            if (_isEditingMode || _isReadOnly)
            {
                LoadContractData();
            }
        }

        private void btnAddSubPeriod_Click(object sender, EventArgs e)
        {
            FrmPeriodAdd frmSubscriptionPeriodAdd = new(_periods);
            frmSubscriptionPeriodAdd.ShowDialog();

            if (frmSubscriptionPeriodAdd.Periods != null && frmSubscriptionPeriodAdd.Periods.Count > 0)
            {
                _periods = frmSubscriptionPeriodAdd.Periods;
                DataGridViewMethods.UpdatePeriodsDataGrid(_periods, dgvPeriods);
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            FrmAttachmentAdd frmAttachmentAdd = new(_attachments);
            frmAttachmentAdd.ShowDialog();

            if (frmAttachmentAdd.Attachments != null && frmAttachmentAdd.Attachments.Count > 0)
            {
                _attachments = frmAttachmentAdd.Attachments;

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
            }
        }

        private void cmsDgvRightClick_Opening(object sender, CancelEventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            if (dgv.Name == nameof(dgvAttachments))
            {
                viewToolStripMenuItem.Visible = true;
            }
            else
            {
                viewToolStripMenuItem.Visible = false;
            }
        }

        private void columnSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            FrmColumnSelector2 frmColumnSelector = new(dgv);
            frmColumnSelector.ShowDialog();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = frmColumnSelector.SelectedColumns.Contains(col.Name);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsDgvRightClick.SourceControl is not DataGridView dgv)
            {
                return;
            }

            if (dgv.Rows.Count == 0)
            {
                return;
            }

            if (dgv.Name == nameof(dgvAttachments))
            {
                var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

                if (dataItem is Models.Attachment selectedItem)
                {
                    _attachments.Remove(selectedItem);
                }
                else
                {
                    throw new Exception("Attachment has not been set or cannot be found");
                }
            }
            else if (dgv.Name == nameof(dgvPeriods))
            {
                var dataItem = dgv.Rows[dgv.SelectedRows[0].Index].DataBoundItem;

                if (dataItem is Period selectedItem)
                {
                    _periods.Remove(selectedItem);
                }
                else
                {
                    throw new Exception("Period has not been set or cannot be found");
                }
            }

            if (dgv.Rows.Count == 0)
            {
                dgv.DataSource = null;
            }
        }

        /// <summary>
        /// This loads the contract data from the SQLite database.  This runs if the ContractName passed at run time is NOT empty.
        /// </summary>
        private void LoadContractData()
        {
            if (_contractData == null)
            {
                MessageBox.Show($"Could not find Contract Data.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            txtName.Text = _contractData.Name;
            txtOrderRef.Text = _contractData.OrderRef;
            txtAgreementId.Text = _contractData.UserAgreementId;
            txtDescription.Text = _contractData.Description;
            numCost.Value = _contractData.Price;
            cmbPaymentFrequency.SelectedIndex = (int)_contractData.PaymentFrequency;

            if (_contractData.ContractPeriods.Count > 0)
            {
                foreach (var period in _contractData.ContractPeriods)
                {
                    _periods.Add(period.Period);
                }

                DataGridViewMethods.UpdatePeriodsDataGrid(_periods, dgvPeriods);
            }

            if (_contractData.ContractAttachments.Count > 0)
            {
                foreach (var attachment in _contractData.ContractAttachments)
                {
                    _attachments.Add(attachment.Attachment);
                }

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.IsRequired("Name", 150))
            {
                return;
            }

            if (txtOrderRef.IsRequired("Order Ref", 150))
            {
                return;
            }

            if (txtAgreementId.IsRequired("Agreement ID", 150))
            {
                return;
            }

            if (!_isEditingMode)
            {
                AddContract();
            }
            else
            {
                UpdateContract();
            }

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"{txtName.Text} saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }

        private void AddContract()
        {
            // check if they already exist
            var search = _dbContext.Contracts
                .FirstOrDefault(x => x.UserAgreementId == txtAgreementId.Text || x.OrderRef == txtOrderRef.Text);

            if (search != null)
            {
                MessageBox.Show("Agreement ID and Order Ref must be UNIQUE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var contractData = new Models.Contract()
            {
                Name = txtName.Text,
                OrderRef = txtOrderRef.Text,
                Description = txtDescription.Text,
                Price = numCost.Value,
                PaymentFrequency = (PaymentFrequency)cmbPaymentFrequency.SelectedIndex,
                UserAgreementId = txtAgreementId.Text
            };

            foreach (var period in _periods)
            {
                ContractPeriod contractPeriod = new()
                {
                    Contract = contractData,
                    Period = period
                };

                contractData.ContractPeriods.Add(contractPeriod);
            }

            foreach (var attachment in _attachments)
            {
                ContractAttachment contractAttachment = new()
                {
                    Attachment = attachment,
                    Contract = contractData
                };

                contractData.ContractAttachments.Add(contractAttachment);
            }

            try
            {
                _dbContext.Contracts.Add(contractData);

                ActionLogMethods.Added(_dbContext, ActionAlertCategory.Contract, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmContractModify>($"{ex}");
            }

        }

        private void UpdateContract()
        {
            if (_contractData == null)
            {
                return;
            }

            var search = _dbContext.Contracts
                .FirstOrDefault(
                    x => x.UserAgreementId == txtAgreementId.Text && x.ContractId != _contractData.ContractId
                 || x.OrderRef == txtOrderRef.Text && x.ContractId != _contractData.ContractId);

            if (search != null)
            {
                MessageBox.Show("Agreement Id and Order Ref must be UNIQUE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _contractData.Name = txtName.Text;
            _contractData.OrderRef = txtOrderRef.Text;
            _contractData.Description = txtDescription.Text;
            _contractData.Price = numCost.Value;
            _contractData.PaymentFrequency = (PaymentFrequency)cmbPaymentFrequency.SelectedIndex;
            _contractData.UserAgreementId = txtAgreementId.Text;


            // Remove Subscription and Attachment associations that are no longer present
            var existingPeriods = _dbContext.ContractPeriods.Where(cp => cp.ContractId == _contractData.ContractId).ToList();
            var existingAttachments = _dbContext.ContractAttachments.Where(ca => ca.ContractId == _contractData.ContractId).ToList();

            foreach (var existingPeriod in existingPeriods)
            {
                bool isPeriodInUpdatedList = _periods.Any(period => period.PeriodId == existingPeriod.PeriodId);

                if (!isPeriodInUpdatedList)
                {
                    _dbContext.Periods.Remove(existingPeriod.Period);
                }
            }

            foreach (var existingAttachment in existingAttachments)
            {
                bool isAttachmentInUpdatedList = _attachments.Any(attachment => attachment.AttachmentId == existingAttachment.AttachmentId);

                if (!isAttachmentInUpdatedList)
                {
                    _dbContext.Attachments.Remove(existingAttachment.Attachment);
                }
            }

            // Update the associated periods for the Contract
            foreach (var period in _periods)
            {
                // Check if the period is already associated with the license
                bool isPeriodAssociated = _contractData.ContractPeriods.Any(cp => cp.PeriodId == period.PeriodId);

                if (!isPeriodAssociated)
                {
                    // If the period is not associated, create a new PeriodLicenses entry
                    ContractPeriod contractPeriod = new()
                    {
                        ContractId = _contractData.ContractId,
                        Contract = _contractData,
                        PeriodId = period.PeriodId,
                        Period = period
                    };

                    _dbContext.ContractPeriods.Add(contractPeriod);
                }
            }

            foreach (var attachment in _attachments)
            {
                bool isAttachmentAssociated = _contractData.ContractAttachments.Any(ca => ca.AttachmentId == attachment.AttachmentId);

                if (!isAttachmentAssociated)
                {
                    ContractAttachment contractAttachment = new()
                    {
                        ContractId = _contractData.ContractId,
                        Contract = _contractData,
                        AttachmentId = attachment.AttachmentId,
                        Attachment = attachment,
                    };

                    _dbContext.ContractAttachments.Add(contractAttachment);
                }
            }

            try
            {
                _dbContext.Contracts.Update(_contractData);
                ActionLogMethods.Updated(_dbContext, Utils.Enums.ActionAlertCategory.Contract, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmContractModify>($"{ex}");
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinForms.Attachments.ViewAttachment viewAttachment = new();
            viewAttachment.View(cmsDgvRightClick, dgvAttachments);
        }
    }
}

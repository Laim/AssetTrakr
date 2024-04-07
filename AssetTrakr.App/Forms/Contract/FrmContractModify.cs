using AssetTrakr.App.Forms.Attachment;
using AssetTrakr.App.Forms.Shared;
using AssetTrakr.App.Helpers;
using AssetTrakr.Database;
using AssetTrakr.Logging;
using AssetTrakr.Models;
using AssetTrakr.Utils.Enums;
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

        public FrmContractModify(int contractId = 0, bool isReadOnly = false)
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();

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

            if (contract != null)
            {
                _contractData = contract;
                _isEditingMode = true;

                // Update general form info
                btnAddUpdate.Text = "Update";
                Text = $"Modify Contract - {_contractData.Name}";
            }

            if (isReadOnly && _contractData != null)
            {
                Helpers.Utils.SetReadOnly(this, deleteToolStripMenuItem);
                Text = $"Viewing License - {_contractData.Name}";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbPaymentFrequency.DataSource = Enum.GetValues(typeof(PaymentFrequency));

            if (_isEditingMode)
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

            btnAddUpdate.Text = "Update";
            Text = $"Modify Contract - {_contractData.Name}";

            txtName.Text = _contractData.Name;
            txtOrderRef.Text = _contractData.OrderRef;
            txtDescription.Text = _contractData.Description;
            numCost.Value = _contractData.Price;
            cmbPaymentFrequency.SelectedIndex = (int)_contractData.PaymentFrequency;

            // TODO: This doesn't work

            if (_contractData.ContractPeriods.Count > 0)
            {
                foreach(var period in  _contractData.ContractPeriods)
                {
                    _periods.Add(period.Period);
                }

                DataGridViewMethods.UpdatePeriodsDataGrid(_periods, dgvPeriods);
            }

            if(_contractData.ContractAttachments.Count > 0)
            {
                foreach(var attachment in _contractData.ContractAttachments)
                {
                    _attachments.Add(attachment.Attachment);
                }

                DataGridViewMethods.UpdateAttachmentDataGrid(_attachments, dgvAttachments);
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 150 || txtName.Text.Length == 0)
            {
                MessageBox.Show("Name is a required field and must be no more than 150 characters.", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtOrderRef.Text.Length > 150 || txtOrderRef.Text.Length == 0)
            {
                MessageBox.Show("Order Ref is a required field and must be no more than 150 characters.", "Order Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!_isEditingMode)
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
                .FirstOrDefault(x => x.Name == txtName.Text || x.OrderRef == txtOrderRef.Text);

            if (search != null)
            {
                MessageBox.Show("Name and Order Ref must be UNIQUE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var contractData = new Models.Contract()
            {
                Name = txtName.Text,
                OrderRef = txtOrderRef.Text,
                Description = txtDescription.Text,
                Price = Convert.ToInt32(numCost.Value),
                PaymentFrequency = (PaymentFrequency)cmbPaymentFrequency.SelectedIndex
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

                ActionLogMethods.Added(_dbContext, Utils.Enums.ActionAlertCategory.Contract, txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\nSee log for more details.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmContractModify>($"{ex}");
            }

        }

        private void UpdateContract()
        {
            if(_contractData == null)
            {
                return;
            }

            var search = _dbContext.Contracts
                .FirstOrDefault(
                    x => x.Name == txtName.Text && x.ContractId != _contractData.ContractId 
                 || x.OrderRef == txtOrderRef.Text && x.ContractId != _contractData.ContractId);

            if(search != null)
            {
                MessageBox.Show("Name and Order Ref must be UNIQUE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _contractData.Name = txtName.Text;
            _contractData.OrderRef = txtOrderRef.Text;
            _contractData.Description = txtDescription.Text;
            _contractData.Price = Convert.ToInt32(numCost.Value);
            _contractData.PaymentFrequency = (PaymentFrequency)cmbPaymentFrequency.SelectedIndex;


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
    }
}

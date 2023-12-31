using AssetTrakr.Database;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmSubscriptionPeriodAdd : Form
    {
        private readonly DatabaseContext _dbContext;

        public List<int> PeriodIds;

        public FrmSubscriptionPeriodAdd(DatabaseContext DbContext, List<int> SubscriptionPeriodIds)
        {
            InitializeComponent();

            _dbContext ??= DbContext;

            PeriodIds ??= [];

            // To account for previously added and prevent data loss on user end
            if(SubscriptionPeriodIds != null )
            {
                PeriodIds = SubscriptionPeriodIds;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dtSubEnd.Value = DateTime.Today.AddYears(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dtSubStart.Value > dtSubEnd.Value)
            {
                MessageBox.Show("Start Date cannot be after the End Date", "Period", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dtSubEnd.Value < dtSubStart.Value)
            {
                MessageBox.Show("End Date cannot be before the Start Date", "Period", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var entry = new Models.Period
            {
                StartDate = DateOnly.FromDateTime(dtSubStart.Value),
                EndDate = DateOnly.FromDateTime(dtSubEnd.Value),
                CreatedBy = "",
                UpdatedBy = "",
            };

            _dbContext.Add(entry);

            if (_dbContext.SaveChanges() > 0)
            {
                MessageBox.Show($"Period saved successfully", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PeriodIds.Add(entry.Id);
            }
            else
            {
                MessageBox.Show($"Period was not added successfully", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

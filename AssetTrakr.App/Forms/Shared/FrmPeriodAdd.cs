using AssetTrakr.Models;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Shared
{
    public partial class FrmPeriodAdd : Form
    {
        public BindingList<Period> Periods;

        public FrmPeriodAdd(BindingList<Period> SubscriptionPeriods)
        {
            InitializeComponent();

            Periods ??= [];

            // To account for previously added and prevent data loss on user end
            if(SubscriptionPeriods != null )
            {
                Periods = SubscriptionPeriods;
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

            Periods.Add(new Period
            {
                StartDate = DateOnly.FromDateTime(dtSubStart.Value),
                EndDate = DateOnly.FromDateTime(dtSubEnd.Value)
            });

            MessageBox.Show("Period added successfully", "Period", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

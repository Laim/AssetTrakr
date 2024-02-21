using AssetTrakr.App.Forms.Asset;
using AssetTrakr.App.Forms.License;
using AssetTrakr.App.Forms.Miscellaneous;
using AssetTrakr.Database;
using System.ComponentModel;

namespace AssetTrakr.App.Forms
{
    public partial class FrmMain : Form
    {

        private DatabaseContext _dbContext;

        public FrmMain()
        {
            InitializeComponent();

            _dbContext ??= new DatabaseContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                _dbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Boot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            LoadWidgets();
        }

        private void LoadWidgets()
        {
            lblLicenseCount.Text = $"{_dbContext.Licenses.Count()}";
            lblAssetCount.Text = $"{_dbContext.Assets.Count()}";

            // set colors
            SetTextColor(this);
        }

        /// <summary>
        /// Sets the color of the labels that contain 'Count' in their name to green if they contain anything other than 0
        /// </summary>
        /// <param name="control">The parent <see cref="Control"/></param>
        private static void SetTextColor(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Label l && l.Name.EndsWith("Count"))
                {
                    if (int.TryParse(l.Text, out int value) && value != 0)
                    {
                        l.ForeColor = Color.Green;
                    }
                }

                if (ctrl.HasChildren)
                {
                    SetTextColor(ctrl);
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext?.Dispose();
        }

        private void addLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new();
            frmLicenseModify.ShowDialog();
        }

        private void viewLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseViewAll frmLicenseViewAll = new();
            frmLicenseViewAll.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLicenseModify frmLicenseModify = new(Convert.ToInt32(textBox1.Text));
            FrmAssetModify FrmAssetModify = new(Convert.ToInt32(textBox1.Text));

            FrmAssetModify.ShowDialog();
        }

        private void addAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssetModify frmAssetModify = new();
            frmAssetModify.ShowDialog();
        }

        private void actionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActionLog frmActionLog = new();
            frmActionLog.ShowDialog();
        }
    }
}

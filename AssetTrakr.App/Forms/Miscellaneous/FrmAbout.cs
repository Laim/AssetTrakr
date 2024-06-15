using AssetTrakr.Database;
using AssetTrakr.Logging;
using System.Diagnostics;
using System.Reflection;

namespace AssetTrakr.App.Forms.Miscellaneous
{
    partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            Text = $"About {AssemblyTitle}";
            lblProductName.Text = $"{AssemblyProduct}";
            lblVersionValue.Text = $"Version: v{AssemblyVersion}";
            lblCopyrightValue.Text = $"Copyright (c) {AssemblyCopyright}";
            lblDescriptionValue.Text = $"AssetTrakr is a License, Contract and Asset Tracker for home use built using EF Core and .NET 8.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(
                    new ProcessStartInfo($"Licenses.txt")
                    {
                        UseShellExecute = true
                    }
                );
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Licenses Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Error<FrmAbout>($"{ex}");
            }
        }
    }
}

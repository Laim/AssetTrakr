using AssetTrakr.Models.Assets;
using System.ComponentModel;

namespace AssetTrakr.App.Forms.Asset
{
    public partial class FrmAssetNetworkAdapterAdd : Form
    {
        public BindingList<AssetNetworkAdapter> NetworkAdapters = [];

        public FrmAssetNetworkAdapterAdd(BindingList<AssetNetworkAdapter> Adapters)
        {
            InitializeComponent();

            NetworkAdapters ??= [];

            // To account for previously added and prevent data loss on user end
            if (Adapters != null)
            {
                NetworkAdapters = Adapters;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NetworkAdapters.Add(new AssetNetworkAdapter
            {
                Name = txtName.Text,
                IpAddress = txtIpAddress.Text,
                MacAddress = txtMacAddress.Text,
            });

            MessageBox.Show($"Adapter added successfully", "Adapter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AssetTrakr.Models.Assets
{
    public class AssetHardware
    {
        [Key]
        public int AssetHardwareId { get; set; }

        public string? Processor { get; set; }
        
        public int RamSizeInMB { get; set; } = 0;

        public int RamSticks { get; set; } = 0;

        public string? BiosSerialNumber { get; set; }

        public List<AssetNetworkAdapter> NetworkAdapters { get; set; } = [];

        public List<AssetHardDrive> HardDrives { get; set; } = [];

    }
}

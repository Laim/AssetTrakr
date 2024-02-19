using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using AssetTrakr.Models.Attributes;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(AssetHardwareId))]
    public class AssetHardware
    {
        [Key]
        public int AssetHardwareId { get; set; }

        public string? Processor { get; set; }

        [DisplayName("Ram (GB)")]
        public int RamSizeInGB { get; set; } = 0;

        [DisplayName("Ram Sticks")]
        public int RamSticks { get; set; } = 0;

        [DisplayName("Bios Serial Number")]
        public string? BiosSerialNumber { get; set; }

        public List<AssetNetworkAdapter> NetworkAdapters { get; set; } = [];

        public List<AssetHardDrive> HardDrives { get; set; } = [];
    }

    [PrimaryKey(nameof(NetworkAdapterId))]
    public class AssetNetworkAdapter
    {
        public int AssetHardwareId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NetworkAdapterId { get; set; }
        
        public required string Name { get; set; }

        [DisplayName("IP Address")]
        public required string IpAddress { get; set; }

        [DisplayName("Mac Address")]
        public required string MacAddress { get; set; }

        public AssetHardware AssetHardware { get; set; }
    }

    [PrimaryKey(nameof(HardDriveId))]
    public class AssetHardDrive
    {
        public int AssetHardwareId { get; set; }

        public int HardDriveId { get; set; }

        public string? Name { get; set; }

        [DisplayName("Serial Number")]
        public string? SerialNumber { get; set; }

        [DisplayName("Size (GB)")]
        public int SizeInGB { get; set; }

        public required int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }

        public AssetHardware AssetHardware { get; set; }

        [DisplayName("Manufacturer")]
        public string ManufacturerName => Manufacturer?.Name;
    }
}

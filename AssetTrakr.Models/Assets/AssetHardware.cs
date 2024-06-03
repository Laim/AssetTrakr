using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssetTrakr.Utils.Enums;
using AssetTrakr.Utils.Attributes;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(AssetHardwareId))]
    public class AssetHardware
    {
        [Key]
        [VisibleByDefault(false)]
        public int AssetHardwareId { get; set; }

        [Display(Name = "Processor", Description = "The Processor the Asset has inside of it")]
        [VisibleByDefault(false)]
        public string? Processor { get; set; }

        [Display(Name = "Ram (GB)", Description = "The amount of RAM the specific Asset has in Total")]
        [VisibleByDefault(false)]
        public int RamSizeInGB { get; set; } = 0;

        [Display(Name = "Ram Sticks", Description = "The total amount of RAM Sticks within the Asset")]
        [VisibleByDefault(false)]
        public int RamSticks { get; set; } = 0;

        [Display(Name = "Serial Number", Description = "The Serial Number of the Asset")]
        [VisibleByDefault(false)]
        public string? BiosSerialNumber { get; set; }

        [Display(Name = "Network Adapters", Description = "The Network Adapters inside of the Asset")]
        [VisibleByDefault(false)]
        public List<AssetNetworkAdapter> NetworkAdapters { get; set; } = [];

        [Display(Name = "Hard Drives", Description = "The Hard Drives inside of the Asset")]
        [VisibleByDefault(false)]
        public List<AssetHardDrive> HardDrives { get; set; } = [];

        [Display(Name = "Type", Description = "The type of asset based on the enum AssetType")]
        [VisibleByDefault]
        public AssetType AssetType { get; set; }
    }

    [PrimaryKey(nameof(NetworkAdapterId))]
    public class AssetNetworkAdapter
    {
        public int AssetHardwareId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [VisibleByDefault(false)]
        public int NetworkAdapterId { get; set; }

        [Display(Name = "Name", Description = "The Name of the Network Adapter")]
        [VisibleByDefault]
        public required string Name { get; set; }

        [Display(Name = "IP Address", Description = "The IP Address of the Network Adapter")]
        [VisibleByDefault]
        public required string IpAddress { get; set; }

        [Display(Name = "Mac Address", Description = "The Mac Address of the Network Adapter")]
        [VisibleByDefault]
        public required string MacAddress { get; set; }

        [VisibleByDefault(false)]
        public AssetHardware AssetHardware { get; set; }
    }

    [PrimaryKey(nameof(HardDriveId))]
    public class AssetHardDrive
    {
        [VisibleByDefault(false)]
        public int AssetHardwareId { get; set; }

        [VisibleByDefault(false)]
        public int HardDriveId { get; set; }

        [Display(Name = "Name", Description = "The Name of the Hard Drive")]
        [VisibleByDefault]
        public string? Name { get; set; }

        [Display(Name = "Serial Number", Description = "The Serial Number of the Hard Drive")]
        [VisibleByDefault]
        public string? SerialNumber { get; set; }

        [Display(Name = "Size", Description = "The Storage Size of the Hard Drive")]
        [VisibleByDefault]
        public int SizeInGB { get; set; }


        [ForeignKey("ManufacturerId")]
        [VisibleByDefault(false)]
        public Manufacturer? Manufacturer { get; set; }

        [VisibleByDefault(false)]
        public AssetHardware AssetHardware { get; set; }
    }
}

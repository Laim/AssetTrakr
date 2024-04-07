using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(AssetId))]
    [Index(nameof(Name), IsUnique = true)]
    [Index("OperatingSystemId", IsUnique = false)]
    public class Asset : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public required string Name { get; set; }

        public required string Model { get; set; }

        [DisplayName("License Key")]
        public string? LicenseKey { get; set; }

        public string? Description { get; set; }

        [DisplayName("Purchase Date")]
        public DateOnly PurchaseDate { get; set; }

        [DisplayName("User")]
        public string? RegisteredUser { get; set; }

        [DisplayName("User Email")]
        public string? RegisteredEmail { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Order Reference")]
        public string? OrderReference { get; set; }

        [DisplayName("Warranty")]
        public bool IsUnderWarranty { get; set; } = false;

        [DisplayName("Warranties")]
        public List<AssetPeriod> AssetPeriods { get; set; } = [];

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        public List<AssetAttachment> AssetAttachments { get; set; } = [];

        [ForeignKey("OperatingSystemId")] // Define ForeignKey attribute to represent the relationship
        public AssetOperatingSystem? OperatingSystem { get; set; } // Direct navigation property to OperatingSystem entity

        [ForeignKey("HardwareId")] // Define ForeignKey attribute to represent the relationship
        public required AssetHardware Hardware { get; set; } // Direct navigation property to Hardware entity

        [ForeignKey("ContractId")] // Define ForeignKey attribute to represent the relationship
        public Contract? Contract { get; set; } // Direct navigation property to Contract entity

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        [ForeignKey("PlatformId")] // Define ForeignKey attribute to represent the relationship
        public Platform? Platform { get; set; } // Direct navigation property to Platform entity

    }
}

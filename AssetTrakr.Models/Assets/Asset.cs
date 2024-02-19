using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(Id))]
    public class Asset : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public required string Name { get; set; }

        public required string Model { get; set; }

        public string? LicenseKey { get; set; }

        public string? Description { get; set; }

        public DateOnly PurchaseDate { get; set; }

        public string? RegisteredUser { get; set; }

        public string? RegisteredEmail { get; set; }

        public int? ContractId { get; set; }

        public required int PlatformId { get; set; }

        public required int ManufacturerId { get; set; }

        public decimal Price { get; set; }

        public string? OrderReference { get; set; }

        public bool IsUnderWarranty { get; set; } = false;

        public List<AssetPeriod> Warranties { get; set; } = [];

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        public List<AssetAttachment> AssetAttachments { get; set; } = [];

        [ForeignKey("OperatingSystemId")] // Define ForeignKey attribute to represent the relationship
        public required AssetOperatingSystem OperatingSystem { get; set; } // Direct navigation property to OperatingSystem entity

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

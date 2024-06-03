using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AssetTrakr.Utils.Attributes;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(AssetId))]
    [Index(nameof(Name), IsUnique = true)]
    [Index("OperatingSystemId", IsUnique = false)]
    public class Asset : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [VisibleByDefault(false)]
        public int AssetId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        [Display(Name = "Name", Description = "The Name of the Asset")]
        [VisibleByDefault]
        public required string Name { get; set; }

        [Display(Name = "Model", Description = "The Model of the Asset")]
        [VisibleByDefault]
        public required string Model { get; set; }

        [Display(Name = "License Key", Description = "The License Key of the Asset")]
        [VisibleByDefault(false)]
        public string? LicenseKey { get; set; }

        [Display(Name = "Description", Description = "The Description of the Asset")]
        [VisibleByDefault(false)]
        public string? Description { get; set; }

        [Display(Name = "Purchase Date", Description = "The Purchase Date of the Asset")]
        [VisibleByDefault]
        public DateOnly PurchaseDate { get; set; }

        [Display(Name = "User", Description = "The Registered User of the Asset")]
        [VisibleByDefault(false)]
        public string? RegisteredUser { get; set; }

        [Display(Name = "User Email", Description = "The Registered User's Email of the Asset")]
        [VisibleByDefault(false)]
        public string? RegisteredEmail { get; set; }

        [Display(Name = "Price", Description = "The Price of the Asset")]
        [VisibleByDefault(false)]
        public decimal Price { get; set; }

        [Display(Name = "Order Reference", Description = "The Order Reference/ID of the Asset Invoice")]
        [VisibleByDefault(false)]
        public string? OrderReference { get; set; }

        [Display(Name = "Has Warranty", Description = "Whether or not the Asset is Under Warranty")]
        [VisibleByDefault]
        public bool IsUnderWarranty { get; set; } = false;

        [Display(Name = "Archived", Description = "Whether or not the contract is Archived")]
        public bool IsArchived { get; set; } = false;

        [Display(Name = "Warranties", Description = "Any warranties assigned to the Asset")]
        [VisibleByDefault]
        public List<AssetPeriod> AssetPeriods { get; set; } = [];

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        [VisibleByDefault(false)]
        public List<AssetAttachment> AssetAttachments { get; set; } = [];

        [ForeignKey("OperatingSystemId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault]
        public AssetOperatingSystem? OperatingSystem { get; set; } // Direct navigation property to OperatingSystem entity

        [ForeignKey("HardwareId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault(false)]
        public required AssetHardware Hardware { get; set; } // Direct navigation property to Hardware entity

        [ForeignKey("ContractId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault(false)]
        public Contract? Contract { get; set; } // Direct navigation property to Contract entity

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault]
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        [ForeignKey("PlatformId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault]
        public Platform? Platform { get; set; } // Direct navigation property to Platform entity

    }
}

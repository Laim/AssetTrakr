using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using AssetTrakr.Utils.Enums;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(Id))]
    public class License : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Count { get; set; } = 0;

        [DisplayName("Purchase Date")]
        public DateOnly PurchaseDate { get; set; }

        /// <summary>
        /// Subscription Periods
        /// </summary>
        public List<LicensePeriod> LicensePeriods { get; set; } = [];

        [DisplayName("Subscription")]
        public bool IsSubscription { get; set; } = false;

        [DisplayName("Subscription via Contract")]
        /// <summary>
        /// If the subscription periods are inherited from the contract
        /// </summary>
        public bool IsSubscriptionContract { get; set; } = false;

        public PaymentFrequency PaymentFrequency { get; set; } = PaymentFrequency.Once;

        // TODO: Deprecate this
        public int? ContractId { get; set; } = 0;

        // TODO: Deprecate this
        public required int ManufacturerId { get; set; }

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        public List<LicenseAttachment> LicenseAttachments { get; set; } = [];

        public decimal Price { get; set; }

        [DisplayName("Order Reference")]
        public string? OrderReference { get; set; }

        public string? Vendor { get; set; }

        public string? Version { get; set; }

        // TODO: Deprecate this
        public int PlatformId { get; set; } = 0;

        [DisplayName("Archived")]
        public bool IsArchived { get; set; } = false;

        [DisplayName("User")]
        public string? RegisteredUser { get; set; }

        [DisplayName("User Email")]
        public string? RegisteredEmail { get; set; }

        [DisplayName("License Key")]
        public string? LicenseKey { get; set; }

        [ForeignKey("ContractId")] // Define ForeignKey attribute to represent the relationship
        public Contract? Contract { get; set; } // Direct navigation property to Contract entity
        
        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        [ForeignKey("PlatformId")] // Define ForeignKey attribute to represent the relationship
        public Platform? Platform { get; set; } // Direct navigation property to Platform entity
    }
}

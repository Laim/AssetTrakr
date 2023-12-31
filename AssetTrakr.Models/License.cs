using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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

        public DateOnly PurchaseDate { get; set; }

        public List<int>? SubscriptionIds { get; set; }

        public bool IsSubscription { get; set; } = false;

        /// <summary>
        /// If the subscription periods are inherited from the contract
        /// </summary>
        public bool IsSubscriptionContract { get; set; } = false;

        public int? ContractId { get; set; } = 0;

        public required int ManufacturerId { get; set; }

        public List<int>? AttachmentIds { get; set; }

        public decimal? Price { get; set; }

        public string? OrderReference { get; set; }

        public string? Version { get; set; }

        public int PlatformId { get; set; } = 0;

        public string? RegisteredUser { get; set; }

        public string? RegisteredEmail { get; set; }

        public string? LicenseKey { get; set; }

        [ForeignKey("ContractId")] // Define ForeignKey attribute to represent the relationship
        public Contract? Contract { get; set; } // Direct navigation property to Contract entity

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        [ForeignKey("PlatformId")] // Define ForeignKey attribute to represent the relationship
        public Platform? Platform { get; set; } // Direct navigation property to Platform entity
    }
}

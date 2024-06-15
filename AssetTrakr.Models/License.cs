using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using AssetTrakr.Utils.Enums;
using AssetTrakr.Utils.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(Id))]
    public class License : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [VisibleByDefault(false)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        [AllowNull]
        [VisibleByDefault]
        [Display(Name = "Name", Description = "The Name of the License")]
        public string Name { get; set; }

        [AllowNull]
        [VisibleByDefault(false)]
        [Display(Name = "Description", Description = "The Description of the License")]
        public string Description { get; set; }

        [Required]
        [VisibleByDefault]
        [Display(Name = "Count", Description = "The Total Entitlement Count of the License")]
        public int Count { get; set; } = 0;

        /// <summary>
        /// N.B: This never gets shown in the Syncfusion Datagrid.  Review comment for <see cref="Purchased"/> for more information.
        /// As a result, VisibleByDefault is set to FALSE to prevent random re-appearance.  Manual review required in future.
        /// </summary>
        [Display(Name = "Purchase Date", Description = "The Purchase Date of the License")]
        [VisibleByDefault(false)]
        public DateOnly PurchaseDate { get; set; }

        /// <summary>
        /// String version of <see cref="PurchaseDate"/> 
        /// <br></br>
        /// <remark>
        /// N.B: For some reason Syncfusion's DataGrid doesn't seem to support 'DateOnly'?  As a result, the PurchaseDate property
        /// never get's shown.  As a work around, we convert it to a string and then show that in the DataGrid instead.
        /// </remark>
        /// </summary>
        [VisibleByDefault]
        [Display(Name = "Purchase Date", Description = "The Purchase Date of the License")]
        public string Purchased { get => PurchaseDate.ToString(); }

        /// <summary>
        /// Subscription Periods
        /// </summary>
        [VisibleByDefault(false)]
        [Display(Name = "License Periods", Description = "The Subscription Periods of the License")]
        public List<LicensePeriod> LicensePeriods { get; set; } = [];

        [VisibleByDefault]
        [Display(Name = "Subscription", Description = "Whether the license is a subscription license or not")]
        public bool IsSubscription { get; set; } = false;

        /// <summary>
        /// If the subscription periods are inherited from the contract
        /// </summary>
        [VisibleByDefault(false)]
        [Display(Name = "Subscription Inherited", Description = "Subscription is inherited from a Contract")]
        public bool IsSubscriptionContract { get; set; } = false;

        [VisibleByDefault(false)]
        [Display(Name = "Payment Freq", Description = "The frequency the license is paid for")]
        public PaymentFrequency PaymentFrequency { get; set; } = PaymentFrequency.Once;

        // TODO: Deprecate this
        [VisibleByDefault(false)]
        public int? ContractId { get; set; } = 0;

        // TODO: Deprecate this
        [VisibleByDefault(false)]
        public required int ManufacturerId { get; set; }

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        [VisibleByDefault(false)]
        public List<LicenseAttachment> LicenseAttachments { get; set; } = [];

        [VisibleByDefault]
        [Display(Name = "Price", Description = "The Price of the License")]
        public decimal Price { get; set; }

        [VisibleByDefault(false)]
        [Display(Name = "Order Reference", Description = "The Order Reference of the License")]
        [AllowNull]
        public string OrderReference { get; set; }

        [VisibleByDefault(false)]
        public string? Vendor { get; set; }

        [VisibleByDefault(false)]
        [AllowNull]
        [Display(Name = "Vendor", Description = "The Vendor the License was purchased from")]
        public string? Version { get; set; }

        // TODO: Deprecate this
        [VisibleByDefault(false)]
        public int PlatformId { get; set; } = 0;

        [Display(Name = "Archived", Description = "Whether the license is archived or not")]
        public bool IsArchived { get; set; } = false;

        [Display(Name = "User", Description = "The Registered User of the License")]
        [VisibleByDefault(false)]
        [AllowNull]
        public string RegisteredUser { get; set; }

        [Display(Name = "User Email", Description = "The Registered User's Email of the License")]
        [VisibleByDefault(false)]
        [AllowNull]
        public string RegisteredEmail { get; set; }

        [Display(Name = "License Key", Description = "The Product Key assigned to the License")]
        [VisibleByDefault(false)]
        [AllowNull]
        public string LicenseKey { get; set; }

        [ForeignKey("ContractId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault(true)]
        public Contract? Contract { get; set; } // Direct navigation property to Contract entity
        
        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault(true)]
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        [ForeignKey("PlatformId")] // Define ForeignKey attribute to represent the relationship
        [VisibleByDefault(true)]
        public Platform? Platform { get; set; } // Direct navigation property to Platform entity
    }
}

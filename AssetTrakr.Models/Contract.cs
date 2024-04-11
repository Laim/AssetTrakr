using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(ContractId))]
    [Index(nameof(UserAgreementId), IsUnique = true)]
    [Index(nameof(OrderRef), IsUnique = true)]
    public class Contract : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public required string OrderRef { get; set; } // UNIQUE

        [Required]
        public required string UserAgreementId { get; set; } // UNIQUE

        /// <summary>
        /// This is used on ComboBoxes on the 'DisplayMember' prop.
        /// </summary>
        public string ComboDisplayName
        {
            get
            {
                if (UserAgreementId != null)
                {
                    return $"{Name}/{UserAgreementId}";
                }
                else
                {
                    return $"{Name}";
                }
            }
        }

        public decimal Price { get; set; }

        public required PaymentFrequency PaymentFrequency { get; set; }

        /// <summary>
        /// Assigned Attachments
        /// </summary>
        public List<ContractAttachment> ContractAttachments { get; set; } = [];

        /// <summary>
        /// Subscription Periods
        /// </summary>
        public List<ContractPeriod> ContractPeriods { get; set; } = [];

        public string? Description { get; set; }

    }
}

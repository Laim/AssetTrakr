using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(ContractId))]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(OrderRef), IsUnique = true)]
    public class Contract : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public required string Name { get; set; } // UNIQUE

        [Required]
        [MaxLength(150)]
        public required string OrderRef { get; set; } // UNIQUE

        [Required]
        public required List<int> SubscriptionIds { get; set; }

        public List<int>? AttachmentIds { get; set; }

        public string? Description { get; set; }

    }
}

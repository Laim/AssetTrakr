using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(ManufacturerId))]
    [Index(nameof(Name), IsUnique = true)]
    public class Manufacturer : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public required string Name { get; set; }

        [MinLength(1)]
        [MaxLength(150)]
        public required string? Url { get; set; }

        [DisplayName("Support Url")]
        public string? SupportUrl { get; set; }

        [DisplayName("Support Email")]
        public string? SupportEmail { get; set; }

        [DisplayName("Support Phone")]
        public string? SupportPhone { get; set; }
        
        public string? Notes { get; set; }
        
        [DisplayName("Archived")]
        public bool IsArchived { get; set; } = false;
    }
}

using Microsoft.EntityFrameworkCore;
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

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public required string? Url { get; set; }

        public string? SupportUrl { get; set; }
        public string? SupportEmail { get; set; }
        public string? SupportPhone { get; set; }
        public string? Notes { get; set; }
    }
}

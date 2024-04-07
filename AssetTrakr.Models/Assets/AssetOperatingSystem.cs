using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetTrakr.Models.Assets
{
    [PrimaryKey(nameof(OperatingSystemId))]
    public class AssetOperatingSystem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatingSystemId { get; set; }

        [MinLength(1)]
        [MaxLength(150)]
        public required string Name { get; set; }

        public string? Notes { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        public Asset Asset { get; set; }
    }
}

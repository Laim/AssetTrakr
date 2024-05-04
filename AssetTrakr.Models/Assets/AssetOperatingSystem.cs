using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DisplayName("Archived")]
        public bool IsArchived { get; set; } = false;

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public required Manufacturer Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

        public Asset Asset { get; set; }
    }
}

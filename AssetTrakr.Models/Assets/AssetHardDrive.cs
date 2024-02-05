using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models.Assets
{
    public class AssetHardDrive
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int SizeInGB { get; set; }

        public required int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")] // Define ForeignKey attribute to represent the relationship
        public Manufacturer? Manufacturer { get; set; } // Direct navigation property to Manufacturer entity

    }
}

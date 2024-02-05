using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models.Assets
{
    public class AssetNetworkAdapter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string IpAddress { get; set; }
        public required string MacAddress { get; set; }
    }
}

using AssetTrakr.Utils.Enums;

namespace AssetTrakr.Models
{
    public class Alert
    {
        public required Severity Severity { get; set; }

        public required string Description { get; set; }

        public required ActionAlertCategory Category { get; set; }
        
    }
}

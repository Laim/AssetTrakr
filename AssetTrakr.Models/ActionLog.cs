using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(ActionId))]

    public class ActionLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }

        [DisplayName("Name")]
        public required string ActionName { get; set; }

        [DisplayName("Category")]
        public required ActionAlertCategory ActionCategory { get; set; }

        [DisplayName("Type")]
        public required ActionType ActionType { get; set; }

        [DisplayName("Timestamp")]
        public DateTime ActionTime { get; set; } = DateTime.Now;

        public string Changes { get; set; } = "Not Logged";

        [DisplayName("Owner")]
        public required string ActionBy { get; set; }
    }
}

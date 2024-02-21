using AssetTrakr.Models.Assets;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(PeriodId))]
    public class Period : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeriodId { get; set; }

        [DisplayName("Start")]
        public required DateOnly StartDate { get; set; }

        [DisplayName("End")]
        public required DateOnly EndDate { get; set; }

        [ForeignKey("PeriodId")] // Define ForeignKey attribute to represent the relationship
        public virtual List<LicensePeriod> LicensePeriods { get; set; } = [];

        [ForeignKey("PeriodId")] // Define ForeignKey attribute to represent the relationship
        public virtual List<ContractPeriod> ContractPeriods { get; set; } = [];

        [ForeignKey("PeriodId")] // Define ForeignKey attribute to represent the relationship
        public virtual List<AssetPeriod> AssetPeriods { get; set; } = [];
    }
}

using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(ReportId))]
    public class Report
    {
        public required int ReportId { get; set; }

        [Comment("ShortCode used at run time for getting reports since ReportId is never guranteed to be the same")]
        public required string ShortCode { get; set; }
        
        public required string Name { get; set; }
        
        public string Description { get; set; } = string.Empty;

        [DisplayName("Requires Criteria")]
        [Comment("Whether or not the report has criteria that can be used during run time")]
        public bool HasCriteria { get; set; }

        [Comment("The type of report, i.e Asset, License etc.  Uses ParentType enum in c#.")]
        public required ParentType ParentType { get; set; }
    }
}

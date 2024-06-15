using AssetTrakr.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AssetTrakr.Models
{
    /// <summary>
    /// Includes fields that are required for all models
    /// </summary>
    public abstract class Base
    {
        [Display(Name = "Created Date", Description = "The date the entity was created")]
        [VisibleByDefault(false)]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

        [Display(Name = "Updated Date", Description = "The date the entity was last updated by a user or system")]
        [VisibleByDefault(false)]
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.Now;

        [Display(Name = "Created By", Description = "Who created the entity, if left blank, returns SYSTEM")]
        [VisibleByDefault(false)]
        public string CreatedBy { get; set; } = "SYSTEM";

        [Display(Name = "Updated By", Description = "Who updated the entity, if left blank, returns SYSTEM")]
        [VisibleByDefault(false)]
        public string UpdatedBy { get; set; } = "SYSTEM";

    }
}

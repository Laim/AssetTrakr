namespace AssetTrakr.Models
{
    /// <summary>
    /// Includes fields that are required for all models
    /// </summary>
    public abstract class Base
    {
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.Now;

        public string CreatedBy { get; set; } = "SYSTEM";
        public string UpdatedBy { get; set; } = "SYSTEM";

    }
}

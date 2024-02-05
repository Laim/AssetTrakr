namespace AssetTrakr.Models.Assets
{
    public class AssetPeriod
    {
        public int? AssetId { get; set; } = null;
        public virtual required Asset Asset { get; set; }

        public int? PeriodId { get; set; } = null;
        public virtual required Period Period { get; set; }
    }
}

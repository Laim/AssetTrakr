namespace AssetTrakr.Models
{
    public class ContractPeriod
    {
        public int? ContractId { get; set; } = null;
        public virtual required Contract Contract { get; set; }

        public int? PeriodId { get; set; } = null;
        public virtual required Period Period { get; set; }
    }
}

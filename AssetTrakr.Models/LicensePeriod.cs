namespace AssetTrakr.Models
{
    public class LicensePeriod
    {
        public int LicenseId { get; set; }
        public License License { get; set; }

        public int PeriodId { get; set; }
        public Period Period { get; set; }
    }
}

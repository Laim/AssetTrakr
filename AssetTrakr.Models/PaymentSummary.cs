namespace AssetTrakr.Models
{
    public class PaymentSummary
    {
        public required string Entity { get; set; }
        public required string PaymentFrequency { get; set; }
        public required decimal TotalCost { get; set; }
    }
}

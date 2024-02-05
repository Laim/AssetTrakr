namespace AssetTrakr.Models
{
    public class ContractAttachment
    {
        public int? ContractId { get; set; } = null;
        public virtual required Contract Contract { get; set; }

        public int? AttachmentId { get; set; } = null;
        public virtual required Attachment Attachment { get; set; }
    }
}

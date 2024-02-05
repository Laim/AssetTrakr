namespace AssetTrakr.Models
{
    public class LicenseAttachment
    {
        public int? LicenseId { get; set; } = null;
        public virtual required License License { get; set; }

        public int? AttachmentId { get; set; } = null;
        public virtual required Attachment Attachment { get; set; }
    }
}

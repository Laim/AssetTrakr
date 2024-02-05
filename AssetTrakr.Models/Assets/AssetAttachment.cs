namespace AssetTrakr.Models.Assets
{
    public class AssetAttachment
    {
        public int? AssetId { get; set; } = null;
        public virtual required Asset Asset { get; set; }

        public int? AttachmentId { get; set; } = null;
        public virtual required Attachment Attachment { get; set; }
    }
}

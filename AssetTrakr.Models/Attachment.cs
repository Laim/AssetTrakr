using AssetTrakr.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTrakr.Models
{
    [PrimaryKey(nameof(AttachmentId))]
    public class Attachment : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public byte[]? Data { get; set; }
        
        public string? DataType { get; set; } // jpg, pdf, png etc.
        public AttachmentType Type { get; set; }
        
        public string? Url { get; set; }

        public bool IsUrl { get; set; } = false;
    }
}

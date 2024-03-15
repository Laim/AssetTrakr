using Microsoft.EntityFrameworkCore;

namespace AssetTrakr.Models
{
    /// <summary>
    /// This is the information for the registered user using AssetTrakr.
    /// 
    /// This information isn't shared or collected outside of the local network, it's purely for Updates etc.
    /// </summary>
    [PrimaryKey(nameof(SysId))]
    public class SystemInfo
    {
        // EFCore doesn't support updating KeyLess entities, and we'll only ever have one of these so just hardcode int 1
        public int SysId { get; set; } = 1;
        public string FullName { get; set; } = string.Empty;
        public string ProductVersion { get; set; } = string.Empty;
        public DateTime DatabaseCreationDate { get; set; } = DateTime.Now;
        public string RunDirectory { get; set; } = string.Empty;
    }
}

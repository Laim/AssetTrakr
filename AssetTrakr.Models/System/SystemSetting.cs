using AssetTrakr.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AssetTrakr.Models.System
{
    [PrimaryKey(nameof(Name))]
    public class SystemSetting
    {
        
        public required string Name { get; set; }
        
        public required string Description { get; set; }
        
        public required SystemSettingsCategory Category { get; set; }

        [DisplayName("Type")]
        public required string SettingParentType { get; set; }

        public required bool Enabled { get; set; }

        [DisplayName("Default Enabled")]
        public bool DefaultEnabled { get; set; }

        [DisplayName("Setting Value")]
        public string? SettingValue { get; set; }

        [DisplayName("Default Setting Value")]
        public string? DefaultSettingValue { get; set; }
    }
}

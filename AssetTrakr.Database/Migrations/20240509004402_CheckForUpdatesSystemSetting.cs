using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class CheckForUpdatesSystemSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "AlertThreshold",
                column: "Category",
                value: 0);

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Name", "Category", "DefaultEnabled", "DefaultSettingValue", "Description", "Enabled", "SettingParentType", "SettingValue" },
                values: new object[] { "CheckForUpdates", 1, true, "stable", "Automatically check for Updates", true, "Updates", "stable" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "CheckForUpdates");

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "AlertThreshold",
                column: "Category",
                value: 1);
        }
    }
}

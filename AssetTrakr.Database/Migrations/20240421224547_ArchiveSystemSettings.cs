using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class ArchiveSystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Name", "Category", "DefaultEnabled", "DefaultSettingValue", "Description", "Enabled", "SettingParentType", "SettingValue" },
                values: new object[,]
                {
                    { "IncludeArchivedInAlerts", 1, true, null, "Includes Archived Entities in Alerts", true, "Archive", null },
                    { "IncludeArchivedInViewAll", 1, true, null, "Includes Archived Entities in View All pages", true, "Archive", null },
                    { "IncludeArchivedInWidgets", 1, true, null, "Includes Archived Entities in Widgets", true, "Archive", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "IncludeArchivedInAlerts");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "IncludeArchivedInViewAll");

            migrationBuilder.DeleteData(
                table: "SystemSettings",
                keyColumn: "Name",
                keyValue: "IncludeArchivedInWidgets");
        }
    }
}

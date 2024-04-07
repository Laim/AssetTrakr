using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTestDatabaseSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssetOperatingSystems",
                keyColumn: "OperatingSystemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "CreatedBy", "CreatedDate", "Name", "Notes", "SupportEmail", "SupportPhone", "SupportUrl", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 1, 0, 0, 0)), "Microsoft", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6959), new TimeSpan(0, 1, 0, 0, 0)), "https://microsoft.com" },
                    { 2, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6966), new TimeSpan(0, 1, 0, 0, 0)), "Adobe, Inc", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6967), new TimeSpan(0, 1, 0, 0, 0)), "https://adobe.com" },
                    { 3, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 1, 0, 0, 0)), "1Password", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 1, 0, 0, 0)), "https://1password.com" },
                    { 4, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 1, 0, 0, 0)), "Valve", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 1, 0, 0, 0)), "https://valvesoftware.com" },
                    { 5, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6975), new TimeSpan(0, 1, 0, 0, 0)), "Apple", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6976), new TimeSpan(0, 1, 0, 0, 0)), "https://apple.com" },
                    { 6, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, 1, 0, 0, 0)), "Citrix", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6979), new TimeSpan(0, 1, 0, 0, 0)), "https://www.citrix.com/" },
                    { 7, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6981), new TimeSpan(0, 1, 0, 0, 0)), "Splunk", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 1, 0, 0, 0)), "https://www.splunk.com/" },
                    { 8, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6983), new TimeSpan(0, 1, 0, 0, 0)), "Amazon", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 1, 0, 0, 0)), "https://amazon.com/" },
                    { 9, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6986), new TimeSpan(0, 1, 0, 0, 0)), "Google", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 1, 0, 0, 0)), "https://google.com/" },
                    { 10, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 1, 0, 0, 0)), "Linux Foundation", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6989), new TimeSpan(0, 1, 0, 0, 0)), "https://linuxfoundation.org/" }
                });

            migrationBuilder.InsertData(
                table: "AssetOperatingSystems",
                columns: new[] { "OperatingSystemId", "ManufacturerId", "Name", "Notes" },
                values: new object[] { 1, 1, "Windows 11", null });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "CreatedBy", "CreatedDate", "ManufacturerId", "Name", "Notes", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 1, 0, 0, 0)), 1, "Windows", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7043), new TimeSpan(0, 1, 0, 0, 0)), 5, "macOS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 3, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7045), new TimeSpan(0, 1, 0, 0, 0)), 10, "Linux", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7046), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 4, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 1, 0, 0, 0)), 9, "Chrome OS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7049), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 5, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7050), new TimeSpan(0, 1, 0, 0, 0)), 5, "iOS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7051), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 6, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 1, 0, 0, 0)), 9, "Android", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7054), new TimeSpan(0, 1, 0, 0, 0)) }
                });
        }
    }
}

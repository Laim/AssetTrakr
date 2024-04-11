using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalReportFieldIsUserVisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserVisible",
                table: "Reports",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                comment: "Whether or not it will be visible in the Report Runner");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "IsUserVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "IsUserVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "IsUserVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "IsUserVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "IsUserVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "IsUserVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 7,
                column: "IsUserVisible",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserVisible",
                table: "Reports");
        }
    }
}

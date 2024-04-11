using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActionLogChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Changes",
                table: "ActionLogEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Changes",
                table: "ActionLogEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddContractUserAgreementId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAgreementId",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAgreementId",
                table: "Contracts");
        }
    }
}

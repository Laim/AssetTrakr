using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddContractUserAgreementIdUniqueNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UserAgreementId",
                table: "Contracts",
                column: "UserAgreementId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_UserAgreementId",
                table: "Contracts");
        }
    }
}

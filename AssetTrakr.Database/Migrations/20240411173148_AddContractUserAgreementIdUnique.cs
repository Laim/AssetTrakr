using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddContractUserAgreementIdUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_Name",
                table: "Contracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Name",
                table: "Contracts",
                column: "Name",
                unique: true);
        }
    }
}

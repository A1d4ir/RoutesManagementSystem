using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangindSettlementIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SettlementId",
                table: "Settlements",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Settlements",
                newName: "SettlementId");
        }
    }
}

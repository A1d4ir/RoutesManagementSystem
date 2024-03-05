using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingSettlementRelationToLastMileRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastMileRouteId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettlementId",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_LastMileRouteId",
                table: "Settlements",
                column: "LastMileRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteId",
                table: "Settlements",
                column: "LastMileRouteId",
                principalTable: "LastMileRoutes",
                principalColumn: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_LastMileRouteId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "LastMileRouteId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "SettlementId",
                table: "Settlements");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DeletingSettlementRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteRouteId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_LastMileRouteRouteId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "LastMileRouteRouteId",
                table: "Settlements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastMileRouteRouteId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_LastMileRouteRouteId",
                table: "Settlements",
                column: "LastMileRouteRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteRouteId",
                table: "Settlements",
                column: "LastMileRouteRouteId",
                principalTable: "LastMileRoutes",
                principalColumn: "RouteId");
        }
    }
}

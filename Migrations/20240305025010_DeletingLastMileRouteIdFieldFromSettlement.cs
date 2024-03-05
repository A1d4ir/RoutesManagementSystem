using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DeletingLastMileRouteIdFieldFromSettlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteId",
                table: "Settlements");

            migrationBuilder.RenameColumn(
                name: "LastMileRouteId",
                table: "Settlements",
                newName: "LastMileRouteRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_LastMileRouteId",
                table: "Settlements",
                newName: "IX_Settlements_LastMileRouteRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteRouteId",
                table: "Settlements",
                column: "LastMileRouteRouteId",
                principalTable: "LastMileRoutes",
                principalColumn: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteRouteId",
                table: "Settlements");

            migrationBuilder.RenameColumn(
                name: "LastMileRouteRouteId",
                table: "Settlements",
                newName: "LastMileRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_LastMileRouteRouteId",
                table: "Settlements",
                newName: "IX_Settlements_LastMileRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_LastMileRoutes_LastMileRouteId",
                table: "Settlements",
                column: "LastMileRouteId",
                principalTable: "LastMileRoutes",
                principalColumn: "RouteId");
        }
    }
}

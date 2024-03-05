using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class DeletingLastMileRoutesFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_LastMileRoutes_RouteId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_RouteId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Settlements");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_RouteId",
                table: "Settlements",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_LastMileRoutes_RouteId",
                table: "Settlements",
                column: "RouteId",
                principalTable: "LastMileRoutes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleship.Webapi.Migrations
{
    public partial class StatsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player1Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Player2Id",
                table: "Stats");

            migrationBuilder.AddColumn<int>(
                name: "Grid1IdId",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grid2IdId",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Player1IdId",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Player2IdId",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dimensions",
                table: "Grids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Grid1IdId",
                table: "Stats",
                column: "Grid1IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Grid2IdId",
                table: "Stats",
                column: "Grid2IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Player1IdId",
                table: "Stats",
                column: "Player1IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Player2IdId",
                table: "Stats",
                column: "Player2IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Grids_Grid1IdId",
                table: "Stats",
                column: "Grid1IdId",
                principalTable: "Grids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Grids_Grid2IdId",
                table: "Stats",
                column: "Grid2IdId",
                principalTable: "Grids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_Player1IdId",
                table: "Stats",
                column: "Player1IdId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_Player2IdId",
                table: "Stats",
                column: "Player2IdId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Grids_Grid1IdId",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Grids_Grid2IdId",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_Player1IdId",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_Player2IdId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Grid1IdId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Grid2IdId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Player1IdId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Player2IdId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Grid1IdId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Grid2IdId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Player1IdId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Player2IdId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "Grids");

            migrationBuilder.AddColumn<int>(
                name: "Player1Id",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Id",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

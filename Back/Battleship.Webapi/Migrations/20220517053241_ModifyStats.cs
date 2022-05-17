using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleship.Webapi.Migrations
{
    public partial class ModifyStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Player2IdId",
                table: "Stats",
                newName: "PlayerVictoryId");

            migrationBuilder.RenameColumn(
                name: "Player1IdId",
                table: "Stats",
                newName: "PlayerTurnId");

            migrationBuilder.RenameColumn(
                name: "Grid2IdId",
                table: "Stats",
                newName: "Player2Id");

            migrationBuilder.RenameColumn(
                name: "Grid1IdId",
                table: "Stats",
                newName: "Player1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Player2IdId",
                table: "Stats",
                newName: "IX_Stats_PlayerVictoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Player1IdId",
                table: "Stats",
                newName: "IX_Stats_PlayerTurnId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Grid2IdId",
                table: "Stats",
                newName: "IX_Stats_Player2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Grid1IdId",
                table: "Stats",
                newName: "IX_Stats_Player1Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Stats",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "Grid1Id",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grid2Id",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Players",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Grid1Id",
                table: "Stats",
                column: "Grid1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Grid2Id",
                table: "Stats",
                column: "Grid2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Grids_Grid1Id",
                table: "Stats",
                column: "Grid1Id",
                principalTable: "Grids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Grids_Grid2Id",
                table: "Stats",
                column: "Grid2Id",
                principalTable: "Grids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_Player1Id",
                table: "Stats",
                column: "Player1Id",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_Player2Id",
                table: "Stats",
                column: "Player2Id",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerTurnId",
                table: "Stats",
                column: "PlayerTurnId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerVictoryId",
                table: "Stats",
                column: "PlayerVictoryId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Grids_Grid1Id",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Grids_Grid2Id",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_Player1Id",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_Player2Id",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerTurnId",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerVictoryId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Grid1Id",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Grid2Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Grid1Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "Grid2Id",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerVictoryId",
                table: "Stats",
                newName: "Player2IdId");

            migrationBuilder.RenameColumn(
                name: "PlayerTurnId",
                table: "Stats",
                newName: "Player1IdId");

            migrationBuilder.RenameColumn(
                name: "Player2Id",
                table: "Stats",
                newName: "Grid2IdId");

            migrationBuilder.RenameColumn(
                name: "Player1Id",
                table: "Stats",
                newName: "Grid1IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_PlayerVictoryId",
                table: "Stats",
                newName: "IX_Stats_Player2IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_PlayerTurnId",
                table: "Stats",
                newName: "IX_Stats_Player1IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Player2Id",
                table: "Stats",
                newName: "IX_Stats_Grid2IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_Player1Id",
                table: "Stats",
                newName: "IX_Stats_Grid1IdId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Stats",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

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
    }
}

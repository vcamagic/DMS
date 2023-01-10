using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class FloorLevelUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Maids_FloorId",
                table: "Maids",
                column: "FloorId",
                unique: true,
                filter: "[FloorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_Level",
                table: "Floors",
                column: "Level",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maids_Floors_FloorId",
                table: "Maids",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maids_Floors_FloorId",
                table: "Maids");

            migrationBuilder.DropIndex(
                name: "IX_Maids_FloorId",
                table: "Maids");

            migrationBuilder.DropIndex(
                name: "IX_Floors_Level",
                table: "Floors");
        }
    }
}

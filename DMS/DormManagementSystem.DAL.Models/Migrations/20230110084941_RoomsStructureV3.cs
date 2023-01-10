using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class RoomsStructureV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id");
        }
    }
}

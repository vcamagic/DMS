using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class MalfunctionRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JanitorMalfunction_Malfunction_MalfunctionsId",
                table: "JanitorMalfunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Malfunction_Students_StudentId",
                table: "Malfunction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malfunction",
                table: "Malfunction");

            migrationBuilder.RenameTable(
                name: "Malfunction",
                newName: "Malfunctions");

            migrationBuilder.RenameIndex(
                name: "IX_Malfunction_StudentId",
                table: "Malfunctions",
                newName: "IX_Malfunctions_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malfunctions",
                table: "Malfunctions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JanitorMalfunction_Malfunctions_MalfunctionsId",
                table: "JanitorMalfunction",
                column: "MalfunctionsId",
                principalTable: "Malfunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Malfunctions_Students_StudentId",
                table: "Malfunctions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JanitorMalfunction_Malfunctions_MalfunctionsId",
                table: "JanitorMalfunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Malfunctions_Students_StudentId",
                table: "Malfunctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malfunctions",
                table: "Malfunctions");

            migrationBuilder.RenameTable(
                name: "Malfunctions",
                newName: "Malfunction");

            migrationBuilder.RenameIndex(
                name: "IX_Malfunctions_StudentId",
                table: "Malfunction",
                newName: "IX_Malfunction_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malfunction",
                table: "Malfunction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JanitorMalfunction_Malfunction_MalfunctionsId",
                table: "JanitorMalfunction",
                column: "MalfunctionsId",
                principalTable: "Malfunction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Malfunction_Students_StudentId",
                table: "Malfunction",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

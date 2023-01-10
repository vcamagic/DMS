using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class RoomsStructureV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidencyId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidencyId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class RoomsStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResidencyId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Entertainments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entertainments_Rooms_Id",
                        column: x => x.Id,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Laundries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laundries_Rooms_Id",
                        column: x => x.Id,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Residencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residencies_Rooms_Id",
                        column: x => x.Id,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ResidencyId",
                table: "Students",
                column: "ResidencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomNumber",
                table: "Rooms",
                column: "RoomNumber",
                unique: true,
                filter: "[RoomNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residencies_ResidencyId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Entertainments");

            migrationBuilder.DropTable(
                name: "Laundries");

            migrationBuilder.DropTable(
                name: "Residencies");

            migrationBuilder.DropIndex(
                name: "IX_Students_ResidencyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ResidencyId",
                table: "Students");
        }
    }
}

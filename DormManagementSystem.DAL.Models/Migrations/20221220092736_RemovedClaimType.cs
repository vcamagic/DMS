using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class RemovedClaimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims");

            migrationBuilder.DropTable(
                name: "ClaimTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claims",
                table: "Claims");

            migrationBuilder.RenameColumn(
                name: "ClaimTypeId",
                table: "Claims",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claims",
                table: "Claims",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Claims",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Claims");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Claims",
                newName: "ClaimTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claims",
                table: "Claims",
                columns: new[] { "ClaimTypeId", "AccountId" });

            migrationBuilder.CreateTable(
                name: "ClaimTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("2d623cd3-0091-422f-a21e-1bf1c62f1bb1"), "Role", "Student" },
                    { new Guid("369f23ac-a293-4b2a-880a-ada25871504a"), "Role", "Warden" },
                    { new Guid("3cf5f75d-5a7b-4c3e-8168-301d7d59aab7"), "Role", "Janitor" },
                    { new Guid("ace9441a-5e06-4f42-bc2a-b88a868a54ac"), "Role", "Doorkeeper" },
                    { new Guid("d1b37397-9438-4c9a-bf2e-b270a3c4e2bf"), "Role", "Administrator" },
                    { new Guid("dc8b25c9-bd59-41ea-bd71-e5d121b2bbc5"), "Role", "Maid" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims",
                column: "ClaimTypeId",
                principalTable: "ClaimTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class AddedDataToClaimType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d623cd3-0091-422f-a21e-1bf1c62f1bb1"));

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("369f23ac-a293-4b2a-880a-ada25871504a"));

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("3cf5f75d-5a7b-4c3e-8168-301d7d59aab7"));

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("ace9441a-5e06-4f42-bc2a-b88a868a54ac"));

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("d1b37397-9438-4c9a-bf2e-b270a3c4e2bf"));

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc8b25c9-bd59-41ea-bd71-e5d121b2bbc5"));
        }
    }
}

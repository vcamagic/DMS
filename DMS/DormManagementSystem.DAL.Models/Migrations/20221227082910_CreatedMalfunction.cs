using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class CreatedMalfunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Malfunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ExpectedFixTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualFixTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malfunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Malfunction_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JanitorMalfunction",
                columns: table => new
                {
                    JanitorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MalfunctionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JanitorMalfunction", x => new { x.JanitorsId, x.MalfunctionsId });
                    table.ForeignKey(
                        name: "FK_JanitorMalfunction_Janitors_JanitorsId",
                        column: x => x.JanitorsId,
                        principalTable: "Janitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JanitorMalfunction_Malfunction_MalfunctionsId",
                        column: x => x.MalfunctionsId,
                        principalTable: "Malfunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JanitorMalfunction_MalfunctionsId",
                table: "JanitorMalfunction",
                column: "MalfunctionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Malfunction_StudentId",
                table: "Malfunction",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JanitorMalfunction");

            migrationBuilder.DropTable(
                name: "Malfunction");
        }
    }
}

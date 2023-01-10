using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    public partial class LaundryCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Laundries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Laundries");
        }
    }
}

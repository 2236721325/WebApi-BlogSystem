using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.API.Models.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "BlogNewses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "BlogNewses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

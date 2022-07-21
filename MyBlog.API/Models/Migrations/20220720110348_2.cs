using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.API.Models.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "BlogNewses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "BlogNewses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

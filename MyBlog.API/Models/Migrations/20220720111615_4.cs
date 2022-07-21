using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.API.Models.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "WriterInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "TypeInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 864, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "BlogNewses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(6658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "WriterInfos");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "TypeInfos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "BlogNewses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(6658));
        }
    }
}

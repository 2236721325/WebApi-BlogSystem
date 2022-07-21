using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.API.Models.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "WriterInfos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "TypeInfos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 864, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "BlogNewses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(6658));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "WriterInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(9899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "TypeInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 864, DateTimeKind.Local).AddTicks(747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "BlogNewses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 20, 19, 16, 14, 863, DateTimeKind.Local).AddTicks(6658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}

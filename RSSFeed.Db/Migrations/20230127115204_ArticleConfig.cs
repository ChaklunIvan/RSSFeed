using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSSFeed.Db.Migrations
{
    /// <inheritdoc />
    public partial class ArticleConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 27, 13, 52, 3, 977, DateTimeKind.Local).AddTicks(2058),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Articles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 1, 27, 13, 52, 3, 977, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Articles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}

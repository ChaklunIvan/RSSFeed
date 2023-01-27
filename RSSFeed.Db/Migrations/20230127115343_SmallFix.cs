using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSSFeed.Db.Migrations
{
    /// <inheritdoc />
    public partial class SmallFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 1, 27, 13, 52, 3, 977, DateTimeKind.Local).AddTicks(2058));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 27, 13, 52, 3, 977, DateTimeKind.Local).AddTicks(2058),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}

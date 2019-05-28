using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Voting.Data.Migrations
{
    public partial class dateIsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "vote",
                newName: "UserName");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "vote",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "electionEnd",
                table: "Party",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "vote");

            migrationBuilder.DropColumn(
                name: "electionEnd",
                table: "Party");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "vote",
                newName: "Username");
        }
    }
}

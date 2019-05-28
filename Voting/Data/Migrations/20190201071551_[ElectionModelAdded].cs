using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Voting.Data.Migrations
{
    public partial class ElectionModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "electionEnd",
                table: "Party");

            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "vote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "Party",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "vote");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "Party");

            migrationBuilder.AddColumn<DateTime>(
                name: "electionEnd",
                table: "Party",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

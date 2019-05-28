using Microsoft.EntityFrameworkCore.Migrations;

namespace Voting.Data.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Party",
                maxLength: 10550,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 550);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Party",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10550);
        }
    }
}

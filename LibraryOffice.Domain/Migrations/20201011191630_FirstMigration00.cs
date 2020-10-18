using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryOffice.Domain.Migrations
{
    public partial class FirstMigration00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname2",
                table: "Publishers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname2",
                table: "Publishers",
                type: "text",
                nullable: true);
        }
    }
}

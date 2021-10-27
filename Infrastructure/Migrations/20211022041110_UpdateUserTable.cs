using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassworrd",
                table: "User",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "AccessFailCount",
                table: "User",
                newName: "AccessFailedCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "User",
                newName: "HashedPassworrd");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "User",
                newName: "AccessFailCount");
        }
    }
}

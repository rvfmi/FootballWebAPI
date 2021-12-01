using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class RegisterUserv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "HashedPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Stadiums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_club_ClubId",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_RoleId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_club",
                table: "club");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "club",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_player_ClubId",
                table: "Players",
                newName: "IX_Players_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "player");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "club");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "users",
                newName: "IX_users_RoleId");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "player",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ClubId",
                table: "player",
                newName: "IX_player_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_player",
                table: "player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_club",
                table: "club",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_player_club_ClubId",
                table: "player",
                column: "ClubId",
                principalTable: "club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Role_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

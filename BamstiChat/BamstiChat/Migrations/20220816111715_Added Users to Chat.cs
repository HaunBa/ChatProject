using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BamstiChat.Migrations
{
    public partial class AddedUserstoChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User1",
                schema: "Identity",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User2",
                schema: "Identity",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User1",
                schema: "Identity",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "User2",
                schema: "Identity",
                table: "Chats");
        }
    }
}

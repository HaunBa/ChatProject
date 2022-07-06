using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BamstiChat.Migrations
{
    public partial class AddedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_User_UserId",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_DestinationUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_SenderUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DestinationUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friend_UserId",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UseId",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                schema: "Identity",
                table: "Messages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationUserId",
                schema: "Identity",
                table: "Messages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DestinationUserId1",
                schema: "Identity",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderUserId1",
                schema: "Identity",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "Friend",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "Friend",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinationUserId1",
                schema: "Identity",
                table: "Messages",
                column: "DestinationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserId1",
                schema: "Identity",
                table: "Messages",
                column: "SenderUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserId1",
                schema: "Identity",
                table: "Friend",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_User_UserId1",
                schema: "Identity",
                table: "Friend",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_DestinationUserId1",
                schema: "Identity",
                table: "Messages",
                column: "DestinationUserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_SenderUserId1",
                schema: "Identity",
                table: "Messages",
                column: "SenderUserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_User_UserId1",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_DestinationUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_SenderUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DestinationUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friend_UserId1",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "DestinationUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderUserId1",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "Friend");

            migrationBuilder.AlterColumn<string>(
                name: "SenderUserId",
                schema: "Identity",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DestinationUserId",
                schema: "Identity",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                schema: "Identity",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                schema: "Identity",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "Friend",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                schema: "Identity",
                table: "Friend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DestinationUserId",
                schema: "Identity",
                table: "Messages",
                column: "DestinationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserId",
                schema: "Identity",
                table: "Messages",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserId",
                schema: "Identity",
                table: "Friend",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_User_UserId",
                schema: "Identity",
                table: "Friend",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_DestinationUserId",
                schema: "Identity",
                table: "Messages",
                column: "DestinationUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_SenderUserId",
                schema: "Identity",
                table: "Messages",
                column: "SenderUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

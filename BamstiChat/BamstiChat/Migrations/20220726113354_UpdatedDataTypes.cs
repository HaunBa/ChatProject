using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BamstiChat.Migrations
{
    public partial class UpdatedDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RetrieverId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_SenderId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RetrieverId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_SenderId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RetrieverId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                schema: "Identity",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RetrieverId",
                schema: "Identity",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RetrieverId",
                schema: "Identity",
                table: "Requests",
                column: "RetrieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SenderId",
                schema: "Identity",
                table: "Requests",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RetrieverId",
                schema: "Identity",
                table: "Requests",
                column: "RetrieverId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_SenderId",
                schema: "Identity",
                table: "Requests",
                column: "SenderId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RetrieverId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_SenderId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RetrieverId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_SenderId",
                schema: "Identity",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                schema: "Identity",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RetrieverId",
                schema: "Identity",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetrieverId1",
                schema: "Identity",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                schema: "Identity",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RetrieverId1",
                schema: "Identity",
                table: "Requests",
                column: "RetrieverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SenderId1",
                schema: "Identity",
                table: "Requests",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RetrieverId1",
                schema: "Identity",
                table: "Requests",
                column: "RetrieverId1",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_SenderId1",
                schema: "Identity",
                table: "Requests",
                column: "SenderId1",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

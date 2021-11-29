using Microsoft.EntityFrameworkCore.Migrations;

namespace GX2.DigitalLibrary.Repositories.Migrations
{
    public partial class Relationship_Many_Books_Many_Users_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId1",
                table: "BookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Books_BookId",
                table: "BookUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser");

            migrationBuilder.DropIndex(
                name: "IX_BookUser_UserId1",
                table: "BookUser");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookUser");

            migrationBuilder.RenameTable(
                name: "BookUser",
                newName: "BookUsers");

            migrationBuilder.RenameIndex(
                name: "IX_BookUser_BookId",
                table: "BookUsers",
                newName: "IX_BookUsers_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookUsers",
                table: "BookUsers",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookUsers_AspNetUsers_UserId",
                table: "BookUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUsers_Books_BookId",
                table: "BookUsers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUsers_AspNetUsers_UserId",
                table: "BookUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUsers_Books_BookId",
                table: "BookUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookUsers",
                table: "BookUsers");

            migrationBuilder.RenameTable(
                name: "BookUsers",
                newName: "BookUser");

            migrationBuilder.RenameIndex(
                name: "IX_BookUsers_BookId",
                table: "BookUser",
                newName: "IX_BookUser_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BookUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UserId1",
                table: "BookUser",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_AspNetUsers_UserId1",
                table: "BookUser",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Books_BookId",
                table: "BookUser",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

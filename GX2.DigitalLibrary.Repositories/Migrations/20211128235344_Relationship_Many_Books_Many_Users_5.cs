using Microsoft.EntityFrameworkCore.Migrations;

namespace GX2.DigitalLibrary.Repositories.Migrations
{
    public partial class Relationship_Many_Books_Many_Users_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "f561d156-f650-4c56-ae1f-dd830f00c2db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b42793f-2a26-4931-a7c6-28f759026180", "AQAAAAEAACcQAAAAECxZW56WtWO97MLgArWF45kvaCoR4110aW8aI9pj5uI8MqF3n7bECAp+/87pTmpGAA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "28c1ce41-35a0-4faf-bdfe-f4cbdc68c986");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "825ab43b-dae5-4359-8038-bad4e1f90b2c", "AQAAAAEAACcQAAAAECr9jKmbri5rFrTAdi756NkdVQGJfVzizMAVOAZd0vkRjNd72Bv1ej3g2lwIOC96bA==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GX2.DigitalLibrary.Repositories.Migrations
{
    public partial class Relationship_Many_Books_Many_Users_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "57e2953d-731c-4b1e-951f-880226281ddb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff554c86-5d44-4bac-afec-0b62e246a918", "AQAAAAEAACcQAAAAEHGX1xMM4t0wqulIOLr2bSPz/Nv5EHtXpXOAyvEOUBWkxy+Zp3345sAGf7ntcBqdMQ==" });
        }
    }
}

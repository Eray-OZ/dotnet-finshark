using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9c42631-91b2-412c-9025-0a42f5015c21", "59b7ac6f-2de2-4670-8946-109a65688027", "User", "USER" },
                    { "b00c4d17-1da1-48db-a79e-cb2addf37388", "c8e6b0a7-89e1-48f0-a2b8-aae496f4c62d", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c42631-91b2-412c-9025-0a42f5015c21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b00c4d17-1da1-48db-a79e-cb2addf37388");
        }
    }
}

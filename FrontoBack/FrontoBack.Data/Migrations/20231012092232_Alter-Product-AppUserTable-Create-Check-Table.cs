using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class AlterProductAppUserTableCreateCheckTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00075b3c-0cfc-4b6f-9a1d-7c7f76aaf171");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3683a736-884d-4c64-8bec-a28e949d9e15", "af5e495e-ae77-4951-8318-a8272ff5a018" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99c5622b-d6f9-4b4e-a099-bb97f5828d16", "c3f0d81a-f885-4d33-ab76-d738d312f9a6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3683a736-884d-4c64-8bec-a28e949d9e15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c5622b-d6f9-4b4e-a099-bb97f5828d16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af5e495e-ae77-4951-8318-a8272ff5a018");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3f0d81a-f885-4d33-ab76-d738d312f9a6");

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    SaleTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    OldPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckProducts_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "727ef898-e71d-4f6c-b94d-e1e27083f8be", "727ef898-e71d-4f6c-b94d-e1e27083f8be", "User", "USER" },
                    { "ac9fbf57-4e5c-431b-b5fa-f4ea68b6741e", "ac9fbf57-4e5c-431b-b5fa-f4ea68b6741e", "Admin", "ADMIN" },
                    { "e9a4faee-dcdf-45a7-a2bd-c27c497842f2", "e9a4faee-dcdf-45a7-a2bd-c27c497842f2", "SupperAdmin", "SUPPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "72a44d7a-559e-4104-aee6-88a4ee0864db", 0, "f934da26-c67d-4356-b023-6b4bdba38862", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEPpI5GJHq/25DQkA9TGxzzJ1jqFM5R/4ifhF3mZmnuhzAWRbh/4OqdfrdN/Lt3yjqg==", null, false, "2ba9503f-8e9f-4ee6-9ade-31a39a27a854", false, "Rufat123" },
                    { "aa0947b4-ec35-475f-8d47-656921e00c7f", 0, "3f0ad74f-c32b-48c4-bb83-2e657612e243", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEB6ZRYQqYWPKouiJa7e1oWSEQluVJHYegkqWqqtHtaGAwQXVUXNBw8phf63sjZP9Mw==", null, false, "989378a4-9c8c-45cf-b18a-23340fdf20a9", false, "Rufat8899" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac9fbf57-4e5c-431b-b5fa-f4ea68b6741e", "72a44d7a-559e-4104-aee6-88a4ee0864db" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9a4faee-dcdf-45a7-a2bd-c27c497842f2", "aa0947b4-ec35-475f-8d47-656921e00c7f" });

            migrationBuilder.CreateIndex(
                name: "IX_CheckProducts_CheckId",
                table: "CheckProducts",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckProducts_ProductId",
                table: "CheckProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_UserId",
                table: "Checks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckProducts");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "727ef898-e71d-4f6c-b94d-e1e27083f8be");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac9fbf57-4e5c-431b-b5fa-f4ea68b6741e", "72a44d7a-559e-4104-aee6-88a4ee0864db" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9a4faee-dcdf-45a7-a2bd-c27c497842f2", "aa0947b4-ec35-475f-8d47-656921e00c7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac9fbf57-4e5c-431b-b5fa-f4ea68b6741e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9a4faee-dcdf-45a7-a2bd-c27c497842f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72a44d7a-559e-4104-aee6-88a4ee0864db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa0947b4-ec35-475f-8d47-656921e00c7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00075b3c-0cfc-4b6f-9a1d-7c7f76aaf171", "00075b3c-0cfc-4b6f-9a1d-7c7f76aaf171", "User", "USER" },
                    { "3683a736-884d-4c64-8bec-a28e949d9e15", "3683a736-884d-4c64-8bec-a28e949d9e15", "Admin", "ADMIN" },
                    { "99c5622b-d6f9-4b4e-a099-bb97f5828d16", "99c5622b-d6f9-4b4e-a099-bb97f5828d16", "SupperAdmin", "SUPPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "af5e495e-ae77-4951-8318-a8272ff5a018", 0, "a517a8ee-1092-43c8-a4d1-9dbba6f83a52", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAELcCU7olT/eV46RfjVzwVN3EYLQRREDwn5Iw7FWm3Pmg7pk+XYefkGPCky9pwIch6Q==", null, false, "1e1b9134-9f73-4629-a073-45d2a04e3e81", false, "Rufat123" },
                    { "c3f0d81a-f885-4d33-ab76-d738d312f9a6", 0, "932922a7-b6ef-4936-97e0-200348e41bb1", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEBSn3BPyn0CmxcXQgEQfFBwUfMcEdW9WPL3V4h8TBkXtr3TK1YFQ+2s1+ZmKBjrn0w==", null, false, "2e85c2a6-e670-4761-91ca-531c10cfea8c", false, "Rufat8899" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3683a736-884d-4c64-8bec-a28e949d9e15", "af5e495e-ae77-4951-8318-a8272ff5a018" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "99c5622b-d6f9-4b4e-a099-bb97f5828d16", "c3f0d81a-f885-4d33-ab76-d738d312f9a6" });
        }
    }
}

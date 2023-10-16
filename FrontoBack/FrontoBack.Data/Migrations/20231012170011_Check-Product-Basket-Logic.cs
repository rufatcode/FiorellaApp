using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class CheckProductBasketLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Checks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3781ccbc-ef5e-4c3f-847e-ea037e602c4d", "3781ccbc-ef5e-4c3f-847e-ea037e602c4d", "User", "USER" },
                    { "b6e1867e-98cc-4429-8086-40bb3316d6b2", "b6e1867e-98cc-4429-8086-40bb3316d6b2", "SupperAdmin", "SUPPERADMIN" },
                    { "ee055689-e60d-4267-ac6a-3fb6ebc13511", "ee055689-e60d-4267-ac6a-3fb6ebc13511", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1dd6af54-4a48-46d8-9b65-d6aaf31510c5", 0, "f4a338d3-700a-4240-be2b-06c51b3e546d", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEBWK5W5drgKZaTuovosvf1JQpwB14BOpFjJ5RIInTnY1VaNrdE+ZHUzBCmRKLTjyug==", null, false, "9918a319-e4b0-4b2b-908f-123ab432be15", false, "Rufat123" },
                    { "dfbb73d5-d440-4584-82f2-ec1a1a1ec108", 0, "0f47a837-5a4d-4417-8c77-7cb20e5b53c3", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEEf133n7Yh1z/6+K6/jpDq24Jn1256m60IHX2FbCSREgfpCZaRm6T/GqIWLec51vQw==", null, false, "7fd355d7-98c2-4c33-9692-eb0605833120", false, "Rufat8899" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ee055689-e60d-4267-ac6a-3fb6ebc13511", "1dd6af54-4a48-46d8-9b65-d6aaf31510c5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6e1867e-98cc-4429-8086-40bb3316d6b2", "dfbb73d5-d440-4584-82f2-ec1a1a1ec108" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3781ccbc-ef5e-4c3f-847e-ea037e602c4d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee055689-e60d-4267-ac6a-3fb6ebc13511", "1dd6af54-4a48-46d8-9b65-d6aaf31510c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6e1867e-98cc-4429-8086-40bb3316d6b2", "dfbb73d5-d440-4584-82f2-ec1a1a1ec108" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6e1867e-98cc-4429-8086-40bb3316d6b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee055689-e60d-4267-ac6a-3fb6ebc13511");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dd6af54-4a48-46d8-9b65-d6aaf31510c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfbb73d5-d440-4584-82f2-ec1a1a1ec108");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Checks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class AlterChecksModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c9150d-a86b-49df-9eb7-da7df159b710");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ddf4f337-b352-4014-9e31-feed978bd87f", "3464af17-249d-4464-9a83-5d83959488bb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b529628-d7b1-4a4d-99f9-e091bba66756", "75b7d33f-9453-4bf5-985d-188ef97be666" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b529628-d7b1-4a4d-99f9-e091bba66756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddf4f337-b352-4014-9e31-feed978bd87f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3464af17-249d-4464-9a83-5d83959488bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b7d33f-9453-4bf5-985d-188ef97be666");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmmount",
                table: "Checks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d487bb7-9f2e-4099-a6bb-4849906a456b", "0d487bb7-9f2e-4099-a6bb-4849906a456b", "Admin", "ADMIN" },
                    { "3d767970-0e91-4c48-80e5-4cb70a75c4d2", "3d767970-0e91-4c48-80e5-4cb70a75c4d2", "SupperAdmin", "SUPPERADMIN" },
                    { "9b0dde2a-82c9-4efc-814c-17aace45ef65", "9b0dde2a-82c9-4efc-814c-17aace45ef65", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0990b467-72dd-4f47-bad5-2fd5338bbf3f", 0, "631b5ab3-321f-413e-8819-775c4b1db3ee", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEICRNQfwJ1aBQnyPGhIFgMxWT9irr1hDupnno2PE6M+zXMwifC4+0SvPkwt0IVPV7w==", null, false, "a3dfbce5-f7e9-458b-8683-326054e4ea4c", false, "Rufat123" },
                    { "0f71cf6d-9b14-4c68-bb0e-b0fd04280c8f", 0, "6a607c16-44af-4f59-b89a-f07013703d03", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEFFwxE7X13HB/g6FqptiTRRf2J9XrCQ7/RzLoos2o+Oqx4Fz1fq7I5Mn+nYtJPz/7Q==", null, false, "b13e9e2f-0ade-4998-80f4-4a7f5d3091ab", false, "Rufat8899" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d487bb7-9f2e-4099-a6bb-4849906a456b", "0990b467-72dd-4f47-bad5-2fd5338bbf3f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d767970-0e91-4c48-80e5-4cb70a75c4d2", "0f71cf6d-9b14-4c68-bb0e-b0fd04280c8f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b0dde2a-82c9-4efc-814c-17aace45ef65");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d487bb7-9f2e-4099-a6bb-4849906a456b", "0990b467-72dd-4f47-bad5-2fd5338bbf3f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d767970-0e91-4c48-80e5-4cb70a75c4d2", "0f71cf6d-9b14-4c68-bb0e-b0fd04280c8f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d487bb7-9f2e-4099-a6bb-4849906a456b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d767970-0e91-4c48-80e5-4cb70a75c4d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0990b467-72dd-4f47-bad5-2fd5338bbf3f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f71cf6d-9b14-4c68-bb0e-b0fd04280c8f");

            migrationBuilder.DropColumn(
                name: "TotalAmmount",
                table: "Checks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61c9150d-a86b-49df-9eb7-da7df159b710", "61c9150d-a86b-49df-9eb7-da7df159b710", "User", "USER" },
                    { "7b529628-d7b1-4a4d-99f9-e091bba66756", "7b529628-d7b1-4a4d-99f9-e091bba66756", "Admin", "ADMIN" },
                    { "ddf4f337-b352-4014-9e31-feed978bd87f", "ddf4f337-b352-4014-9e31-feed978bd87f", "SupperAdmin", "SUPPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3464af17-249d-4464-9a83-5d83959488bb", 0, "6072528f-b2e0-4d38-9fde-55907c471631", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEHVH7vxtklR2ORATVAtCiJZokM1ijojvh4aPkctRPgjtf8M/iCcHvTVL7l8XhTUL5w==", null, false, "c9b36e61-6875-4d9a-8e90-95a5b40076d0", false, "Rufat8899" },
                    { "75b7d33f-9453-4bf5-985d-188ef97be666", 0, "479ef544-74f3-4c83-88d5-078c4b78150e", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAECSWOs9d1MmPT6n7oBI6EG+EaTv2a8M8hLKs3Q4P0UDxdsNWd4IRu5h38a9oVdKYFQ==", null, false, "e29d905f-2024-4967-a2cc-45cc58754ad8", false, "Rufat123" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ddf4f337-b352-4014-9e31-feed978bd87f", "3464af17-249d-4464-9a83-5d83959488bb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7b529628-d7b1-4a4d-99f9-e091bba66756", "75b7d33f-9453-4bf5-985d-188ef97be666" });
        }
    }
}

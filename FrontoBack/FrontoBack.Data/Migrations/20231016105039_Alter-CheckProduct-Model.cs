using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class AlterCheckProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81953d2d-699d-45ad-8e30-34b4b3b6af2f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b50f6810-b074-4530-bac1-950b09be4309", "7524d688-8c53-4ac1-bcd5-0dae4c8f7fff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6c5ee0b0-a38b-42de-bda0-0c69b24148d8", "809b0af0-0b0b-44bf-b1c9-7c17003d2901" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5ee0b0-a38b-42de-bda0-0c69b24148d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b50f6810-b074-4530-bac1-950b09be4309");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7524d688-8c53-4ac1-bcd5-0dae4c8f7fff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "809b0af0-0b0b-44bf-b1c9-7c17003d2901");

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "CheckProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "CheckProducts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c5ee0b0-a38b-42de-bda0-0c69b24148d8", "6c5ee0b0-a38b-42de-bda0-0c69b24148d8", "Admin", "ADMIN" },
                    { "81953d2d-699d-45ad-8e30-34b4b3b6af2f", "81953d2d-699d-45ad-8e30-34b4b3b6af2f", "User", "USER" },
                    { "b50f6810-b074-4530-bac1-950b09be4309", "b50f6810-b074-4530-bac1-950b09be4309", "SupperAdmin", "SUPPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7524d688-8c53-4ac1-bcd5-0dae4c8f7fff", 0, "3c15396a-5007-4b5e-8160-c84a50ada35a", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEI6nAXXd7WBtbWk7Z+GV+oE3uXzep0xc6/fOxduSEfxSV/Cwp3oCeiC+kXnN5UNYHw==", null, false, "792fa06c-d3df-47df-8b01-9653f0cbf5f9", false, "Rufat8899" },
                    { "809b0af0-0b0b-44bf-b1c9-7c17003d2901", 0, "a102a61c-88dc-4010-a508-d46160e62bd1", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEF1vg3WtJsdAiXep1GzW5PmjUNbqIRx9uFJZNqsS0WIjlN4HdDosi7akl862cqjA6A==", null, false, "cf7ebac7-2a2e-48d3-be7c-0e34100392ce", false, "Rufat123" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b50f6810-b074-4530-bac1-950b09be4309", "7524d688-8c53-4ac1-bcd5-0dae4c8f7fff" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6c5ee0b0-a38b-42de-bda0-0c69b24148d8", "809b0af0-0b0b-44bf-b1c9-7c17003d2901" });
        }
    }
}

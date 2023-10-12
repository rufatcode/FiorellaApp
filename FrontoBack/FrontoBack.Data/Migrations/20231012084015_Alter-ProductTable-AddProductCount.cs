using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class AlterProductTableAddProductCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afc9f227-f237-400e-aeb9-0ea374a85e4a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af6cc57f-b881-400e-8e3c-afd295295273", "7a153f21-1d1c-4693-b582-7f9522abca00" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e684c9fb-eb25-4e32-be0b-bcd1c029caf4", "d5d80204-561e-4288-a7f6-95ed6edca841" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af6cc57f-b881-400e-8e3c-afd295295273");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e684c9fb-eb25-4e32-be0b-bcd1c029caf4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a153f21-1d1c-4693-b582-7f9522abca00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5d80204-561e-4288-a7f6-95ed6edca841");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af6cc57f-b881-400e-8e3c-afd295295273", "af6cc57f-b881-400e-8e3c-afd295295273", "SupperAdmin", "SUPPERADMIN" },
                    { "afc9f227-f237-400e-aeb9-0ea374a85e4a", "afc9f227-f237-400e-aeb9-0ea374a85e4a", "User", "USER" },
                    { "e684c9fb-eb25-4e32-be0b-bcd1c029caf4", "e684c9fb-eb25-4e32-be0b-bcd1c029caf4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7a153f21-1d1c-4693-b582-7f9522abca00", 0, "191fd9d7-3fd4-47f3-b4c5-c1b73fa200d0", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEGwoksBCd8/gOa4Tp/hzd1jDAcmanOVVyvH7u6Qpdias8dbPt3aT2b1hL+kAh2lAEQ==", null, false, "9c37dbe0-e45a-413c-8e18-79a29d39ea85", false, "Rufat8899" },
                    { "d5d80204-561e-4288-a7f6-95ed6edca841", 0, "17696a70-11c3-4253-8851-6b6b82ad5d30", "rufatri@code.edu.az", true, "RufatCode", false, false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEFFIHlOE42dXsp9CpB0+ObN8atwvOP9SuF6NC08UUZFO+ZUjuhTaDcg6zAgMbBFGdg==", null, false, "49955b7c-7376-4ea3-9fee-03b375311b62", false, "Rufat123" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "af6cc57f-b881-400e-8e3c-afd295295273", "7a153f21-1d1c-4693-b582-7f9522abca00" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e684c9fb-eb25-4e32-be0b-bcd1c029caf4", "d5d80204-561e-4288-a7f6-95ed6edca841" });
        }
    }
}

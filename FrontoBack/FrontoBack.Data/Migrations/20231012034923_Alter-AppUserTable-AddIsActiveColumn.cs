using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class AlterAppUserTableAddIsActiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcf8edab-378d-4e1f-be3a-e57ad4c77c27");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "463d4990-deaf-4036-822c-f5db4e7116fa", "ee89b571-c56f-4c89-888e-28a0ff832506" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2ad6c86-e487-4895-9480-273acbe242fc", "ff216c6a-166d-432c-a35a-96ea7e534efa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463d4990-deaf-4036-822c-f5db4e7116fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2ad6c86-e487-4895-9480-273acbe242fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee89b571-c56f-4c89-888e-28a0ff832506");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff216c6a-166d-432c-a35a-96ea7e534efa");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463d4990-deaf-4036-822c-f5db4e7116fa", "463d4990-deaf-4036-822c-f5db4e7116fa", "Admin", "ADMIN" },
                    { "b2ad6c86-e487-4895-9480-273acbe242fc", "b2ad6c86-e487-4895-9480-273acbe242fc", "SupperAdmin", "SUPPERADMIN" },
                    { "dcf8edab-378d-4e1f-be3a-e57ad4c77c27", "dcf8edab-378d-4e1f-be3a-e57ad4c77c27", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ee89b571-c56f-4c89-888e-28a0ff832506", 0, "2533ca4d-cc04-42bf-8c68-22c7305482fc", "rufatri@code.edu.az", true, "RufatCode", false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEL672BAUU9uCXc1phfwxVgh/D8GMZpFObirBNEZcze6mJ4cgNl1avrK2Zl8Mmz58GA==", null, false, "1be0f4c3-afcc-4fec-b44c-c78c2cf9ff33", false, "Rufat123" },
                    { "ff216c6a-166d-432c-a35a-96ea7e534efa", 0, "1e9085ab-cdfe-4eb6-968a-10ce947fa96c", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAEFF22PYY+392/KPOTvYDB9GiJfvvAFVE5dIfpQu87CqTTrdWD4KqDdbRl2VKQ4YaeA==", null, false, "d33c26cd-8b23-4e3b-96e8-c8dd7ae36c18", false, "Rufat8899" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "463d4990-deaf-4036-822c-f5db4e7116fa", "ee89b571-c56f-4c89-888e-28a0ff832506" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b2ad6c86-e487-4895-9480-273acbe242fc", "ff216c6a-166d-432c-a35a-96ea7e534efa" });
        }
    }
}

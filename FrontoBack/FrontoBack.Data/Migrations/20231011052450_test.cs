using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontoBack.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "165ccbeb-8d45-43a5-9b2f-9128a3212d64", "165ccbeb-8d45-43a5-9b2f-9128a3212d64", "SupperAdmin", "SUPPERADMIN" },
                    { "c68b1493-6b4d-44a4-8d56-47ee517c7ed2", "c68b1493-6b4d-44a4-8d56-47ee517c7ed2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2efa3fef-4a5f-4f7a-8613-50de986af5ac", 0, "590a4d82-343c-40b0-aebf-74ec5e091723", "rft.smayilov@mail.ru", false, "RufatConputerScience", false, null, "RFT.SMAYILOV@MAIL.RU", "RUFAT8899", "AQAAAAEAACcQAAAAED8p6pEs9sW/FP812gl80yrGh5pDaCDQTW1CzMfkaQN86Q+0jaeOYaco6sFbr4IylA==", null, false, "8a0e7ee6-49d5-451a-93f5-919313b5e3c5", false, "Rufat8899" },
                    { "34ab928a-1886-4237-8129-a831b0ed6b52", 0, "e64159b4-5f2e-418e-af75-c1fc589951ee", "rufatri@code.edu.az", true, "RufatCode", false, null, "RUFATRI@CODE.EDU.AZ", "RUFAT123", "AQAAAAEAACcQAAAAEAVPPUUrut0VWaG/tEtw/4QbgoFfAwgUqKrcEeJlu2pbfrqCN1JLS/oWvr+j0bk3xQ==", null, false, "ef81f116-10b8-482a-97aa-9e21329392bf", false, "Rufat123" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "165ccbeb-8d45-43a5-9b2f-9128a3212d64", "2efa3fef-4a5f-4f7a-8613-50de986af5ac" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c68b1493-6b4d-44a4-8d56-47ee517c7ed2", "34ab928a-1886-4237-8129-a831b0ed6b52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "165ccbeb-8d45-43a5-9b2f-9128a3212d64", "2efa3fef-4a5f-4f7a-8613-50de986af5ac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c68b1493-6b4d-44a4-8d56-47ee517c7ed2", "34ab928a-1886-4237-8129-a831b0ed6b52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "165ccbeb-8d45-43a5-9b2f-9128a3212d64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c68b1493-6b4d-44a4-8d56-47ee517c7ed2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2efa3fef-4a5f-4f7a-8613-50de986af5ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34ab928a-1886-4237-8129-a831b0ed6b52");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKP.TicketPage.Domain.Migrations
{
    public partial class v031800 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeverityFlag = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "01cf4402-6cf0-4b14-9256-d9ae74649d9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "82040ea4-e0ea-43a2-9d7e-5f4fa39fde6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2ec60c00-104a-42df-917c-dd5bd13e5e65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "33dd177e-c1bd-4b6b-9f8c-ab551837de95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "beba1154-d33b-4eec-aac9-76a521ae24b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1ef14777-8891-4ccd-8f2e-3c3c088335b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c315904e-6a8a-45ea-ae56-e9225c07cc8d", "AQAAAAEAACcQAAAAEKqCuTgNNCUxAseb+q6qzirplLgbi+ts2VMaRvHB1XnCOuGg0O1GgrBJ/e9+2x62UA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c72638b2-dd6a-4fbb-aeda-bdf9c7f10aef", "AQAAAAEAACcQAAAAEJGFgetpjVLraw8j884ruDVev1bdNLMaDGD2Jyf3VHRMJWyyImMYuPiAQsm1DAu4fA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd569cd3-3b49-4e74-8867-9d62f23eea4a", "AQAAAAEAACcQAAAAEModC4BZkVJHrrZsB0DO0RCkn9UvGUc3mJJbnYILQ6tea3m+aA/TIhfomW8y/a1cWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3dddac94-3b9c-42c1-ac4f-c15de57effa7", "AQAAAAEAACcQAAAAEJVnA7glpfkTp6Dv1zkTIoNZbj2NdMM7XkbDMDjb/4rEtbjanzYBK9nW9D1uNqyYbw==" });

            migrationBuilder.InsertData(
                table: "LogEntries",
                columns: new[] { "ID", "LogDate", "Message", "RequestID", "SeverityFlag", "StackTrace" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 21, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559), "My Critical Log", "220521001", 0, null },
                    { 3, new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559), "My Warning Log 3", "220525003", 1, null },
                    { 2, new DateTime(2022, 5, 23, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559), "My Info Log 2", "220523002", 2, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8d0ea39e-7738-4a24-bc25-ad2f3a3810f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1d45e143-9e79-4083-b0ea-d8c35d3caf32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "333f1e3c-fc55-4e54-8ce1-15ef04483fcc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "c56a6528-411c-4a37-9610-507abc9d5b8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "0ad83c9f-fc57-4a25-a6a1-2773c192cdff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2ca9fffe-1730-49f1-9c41-9b6e145c9f1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "266f895a-35c4-4144-9efd-ac392c7ff297", "AQAAAAEAACcQAAAAEOfGzpayTJc4t8XfXDVCs206tUAMviMgpPQm/AbnT8uhGGk0lHe9hdXeZ4EuO95/Ug==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "955328ee-431c-4227-bdb5-e32d89d65f6c", "AQAAAAEAACcQAAAAEC31yXve1oJ24SiVbwoRA3Uu9pNcHEEwPVYRRFo566N+BgHsZxCh8HiGs/KVhYFiHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23a277d2-8a61-4b18-88db-0594825d9820", "AQAAAAEAACcQAAAAEOFbKbd4B1tjLi4Nv7tqAEgOtbj/yz5GaGHivkZtZjoqVXgagCkPcaVuCQRPKVPraA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7292f10-097f-4fb0-9062-798fa1f61ccb", "AQAAAAEAACcQAAAAEHpJcwg8/JDtTE7EddmTUt4+qMpnDrEjqJoyosB7IO4Qiwk+fjaxgsTI+sDvRkRrww==" });
        }
    }
}

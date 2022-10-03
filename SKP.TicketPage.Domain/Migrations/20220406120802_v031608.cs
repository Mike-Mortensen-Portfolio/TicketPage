using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKP.TicketPage.Domain.Migrations
{
    public partial class v031608 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludePrefix",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b619f73-1feb-4448-a41c-c8cc7e7922d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "04ddb078-f922-447f-9576-c7b0d8306eac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "15defc0a-de83-4da9-adb3-faabff1c9fba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "439e739a-8f01-4daa-b97e-47f4fcf85537");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "0bb98899-146f-4a5d-92ef-401c56019009");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "45951b47-bde5-4fa5-bcfb-a1c2816fc772");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97812814-7482-4bad-9f72-0ab4558e9660", "AQAAAAEAACcQAAAAEHBqvH/5TCuwOp7Y3mXpcOgukm5LkHl0DfMmwz09ysfB7XGjephgQm/rxT/6wsFrHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52bcd117-047e-4921-85e4-39022738f01c", "AQAAAAEAACcQAAAAEJagvtqjOi3/6Y5yXtKxAYTAnJ83SE/C3YEjjDHoEYSWEPH5l62+YhTNMs9tjM/UvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1aeb2d5c-daaf-4edb-9b4d-69dfda865252", "AQAAAAEAACcQAAAAEITP8rQYLP0QGBNc0RulbPWuBzOLtHICZyv76yY8OsfJ+/AQZY+1rjasGBTetEgnMA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee788289-7184-42e4-89a4-465d41aa2b2f", "AQAAAAEAACcQAAAAEC/ILDceOkQyBGyvnF6wJOqPcw6lED6KVpPofBlmFIv0SZRZyaTNxZ7WUas2CiiggA==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 6, 14, 8, 2, 375, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 6, 14, 8, 2, 375, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 6, 14, 8, 2, 375, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 1,
                column: "IncludePrefix",
                value: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Prefix",
                value: "EL");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IncludePrefix", "Prefix" },
                values: new object[] { true, "E" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 4,
                column: "IncludePrefix",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 8, 2, 369, DateTimeKind.Local).AddTicks(4284), "A220406001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 8, 2, 369, DateTimeKind.Local).AddTicks(4284), "A220406002" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 8, 2, 369, DateTimeKind.Local).AddTicks(4284), "E220406001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 8, 2, 369, DateTimeKind.Local).AddTicks(4284), "220406001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 8, 2, 369, DateTimeKind.Local).AddTicks(4284), "I220406001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludePrefix",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8cf8945d-c45c-4df1-b3e1-ae5a13c0646f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "09d130c8-ef7a-4443-ac96-d3237907d87f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0dc1210b-b421-4b3f-aeb8-045b9b4ce74e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "88aead10-7bc1-400e-a701-aae84fae2281");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "ddd576cf-c2bb-4b87-bd17-dfb9d95ba721");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d7ad7a4d-7558-4a3a-8fb4-ab8d1076c85c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8392c44e-4a25-45ff-87a8-687d48ab8614", "AQAAAAEAACcQAAAAEHAYXIcLpdP2Zy8kOCqdAdYsKTsLu7f0d79js1Fzl5HX+S0dH0rplO0FDtO5RM5GxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1273483-d962-4839-9936-e535b83996f2", "AQAAAAEAACcQAAAAEIEd3+QygN7GSnkFJ8/goq9nRMn4mh4y4x0ig/9whnNrZ+sBK5N3L8dNFQ9tfGvUCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bbe8a6ab-e3d4-4f71-8d8a-20ff3c244352", "AQAAAAEAACcQAAAAEJFRpMH/b2Pfd1dvvMrWNwZUJ/Sn8o3zsAIZO8u0sxMQ1Tdu0XFRb+sup28BmlC6Nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af15fcf5-988c-4ffc-a60e-4ff8669f4bcf", "AQAAAAEAACcQAAAAEJZNseFnbyngGPrgaISU9xKtFAlLjwjt1vF2mXzCSRasqgOwy9pjk6LeiSsj0iagJw==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 2, 16, 48, 10, 725, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 2,
                column: "Prefix",
                value: "E");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 3,
                column: "Prefix",
                value: "");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), "A220402001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), "A220402002" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), "E220402001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), "220402001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), "I220402001" });
        }
    }
}

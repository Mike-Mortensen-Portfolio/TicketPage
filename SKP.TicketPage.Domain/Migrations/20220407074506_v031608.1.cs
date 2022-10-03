using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKP.TicketPage.Domain.Migrations
{
    public partial class v0316081 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d64f7c72-c1ec-4140-95bc-0ec65d43669e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a9a35c1a-27c7-425b-be85-deed6265c3d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "aaaee226-293a-424e-b48f-406a894f383f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "06a76f64-f56c-4bfe-aacd-6f40769c890d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "c33306f3-8a7a-477b-bb0e-443d6f863cda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b9452eea-64ca-4001-99e2-5defd10441e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56d04aa5-d393-4619-b12c-5c14d3f203e0", "AQAAAAEAACcQAAAAEJzgOjw21P3+jYa9prFma1wOfVUAlOIACg6dlxrcHBoOZpELKaQJMDfteV1C8GV6Gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53917102-4166-4d4c-a007-e381bcc6ec62", "AQAAAAEAACcQAAAAEKBrnfAHXheiDMRkGxnSWDjfuCNxrdJryZYxvEJZVU1HTg+EpnPnpx5OXUdjsefIDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07e4c300-870c-4052-af5d-eb301346152e", "AQAAAAEAACcQAAAAEDXraS/UPrCs+gQDca8MTN2Ia7mnuDTJln07BH0/9UTHB9TW12t/DtgZ0UlB7Owf7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb60ce14-fb6b-4083-ad33-3f4c9548ffc4", "AQAAAAEAACcQAAAAELqThc7/MYj+dzGoePriv3AyMoJfFF2LZDmcbYo6CdsrQt1vrAByNZFq4i48b3copg==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 381, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 381, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 381, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561), "A220407001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561), "A220407002" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561), "E220407001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561), "220407001" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DateOfCreation", "TicketNumber" },
                values: new object[] { new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561), "I220407001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

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
    }
}

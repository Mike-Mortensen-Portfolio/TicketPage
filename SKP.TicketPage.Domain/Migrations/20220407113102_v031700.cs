using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKP.TicketPage.Domain.Migrations
{
    public partial class v031700 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f9be2e5e-24f1-4cf1-9e92-37a0041538d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0cb4350d-e10d-40c9-8d3e-cc13eab7f29a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "26d7726c-84d8-4c0d-ac8d-13ae7eb2be96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bb368a79-dcce-429a-a35d-18d7e4d35589");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "0c523cfe-0152-403a-831f-a923af9d6f58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ab3cf7db-a327-4acd-9c8e-a754d9a6bb02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec8a62d9-ba08-4fff-a78c-2db65c7b9731", "AQAAAAEAACcQAAAAEJIYPV3bDJiO3p9jduHLfyN+FkJnichfJXL5bHS5T3Os8odOfXVUPy9YbrRnAsy03Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d9ef59b-3484-4073-8e88-62bd0d3618cf", "AQAAAAEAACcQAAAAENaacqXMy72GAEx+l3ocPYW31qaCy9v5G8OOA+W+/NukAWx6VsKSeM+N0Kim5GmdCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5caadd1d-c805-4ebf-8835-255e5254fea9", "AQAAAAEAACcQAAAAEGmWYLoEgZ3KzB2i/DJ3/zREUf5VFZiDMmEbGowxfYTQ62gPPY1RZorfiFsZnczntQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3326248e-0f9d-4e21-b0f3-5a5cbe579575", "AQAAAAEAACcQAAAAEP41IHYT+6t63eaK+TMNAgq/F2ft2lPu5/88nwJdLhbg+WxwdPDLrkVuOmrUN/qkrA==" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 670, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 670, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 670, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 664, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 664, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 664, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 664, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 13, 31, 1, 664, DateTimeKind.Local).AddTicks(9637));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 3,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 4,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 5,
                column: "DateOfCreation",
                value: new DateTime(2022, 4, 7, 9, 45, 5, 376, DateTimeKind.Local).AddTicks(1561));
        }
    }
}

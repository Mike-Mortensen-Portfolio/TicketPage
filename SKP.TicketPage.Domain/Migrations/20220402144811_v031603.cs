using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKP.TicketPage.Domain.Migrations
{
    public partial class v031603 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2450)", maxLength: 2450, nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1225)", maxLength: 1225, nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTickets",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTickets", x => new { x.EmployeeID, x.TicketID });
                    table.ForeignKey(
                        name: "FK_EmployeeTickets_AspNetUsers_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTickets_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "DisplayName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "8cf8945d-c45c-4df1-b3e1-ae5a13c0646f", "A system role used to provide auto content", "System", "System", "SYSTEM" },
                    { 2, "09d130c8-ef7a-4443-ac96-d3237907d87f", "No elevated permissions", "Normal", "Base", "BASE" },
                    { 3, "0dc1210b-b421-4b3f-aeb8-045b9b4ce74e", "Adminsitrator access to the system", "Admin", "Admin", "ADMIN" },
                    { 4, "88aead10-7bc1-400e-a701-aae84fae2281", "Super user with access to the entire system", "Instruktør", "Instructor", "INSTRUCTOR" },
                    { 5, "ddd576cf-c2bb-4b87-bd17-dfb9d95ba721", "Deep access to internal data", "Udvikler", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "DepartmentID", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, false, "d7ad7a4d-7558-4a3a-8fb4-ab8d1076c85c", null, null, false, "System", "", false, null, null, null, null, null, false, "SystemSeed", false, null });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "Name", "Prefix" },
                values: new object[,]
                {
                    { 1, "Automatik", "A" },
                    { 2, "Elektriker", "E" },
                    { 3, "Elektronik", "" },
                    { 4, "ITM", "I" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 1, 1, "EmployeeRole" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "DepartmentID", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, true, "8392c44e-4a25-45ff-87a8-687d48ab8614", 1, "MyDeveloper@Test.com", true, "My", "Developer", false, null, "MYDEVELOPER@TEST.COM", "MYDEVELOPER@TEST.COM", "AQAAAAEAACcQAAAAEHAYXIcLpdP2Zy8kOCqdAdYsKTsLu7f0d79js1Fzl5HX+S0dH0rplO0FDtO5RM5GxA==", null, false, "DeveloperSeed", false, "MyDeveloper@Test.com" },
                    { 5, 0, true, "af15fcf5-988c-4ffc-a60e-4ff8669f4bcf", 1, "MyUser@Test.com", true, "My", "User", false, null, "MYUSER@TEST.COM", "MYUSER@TEST.COM", "AQAAAAEAACcQAAAAEJZNseFnbyngGPrgaISU9xKtFAlLjwjt1vF2mXzCSRasqgOwy9pjk6LeiSsj0iagJw==", null, false, "UserSeed", false, "MyUser@Test.com" },
                    { 3, 0, true, "d1273483-d962-4839-9936-e535b83996f2", 2, "MyInstructor@Test.com", true, "My", "Instructor", false, null, "MYINSTRUCTOR@TEST.COM", "MYINSTRUCTOR@TEST.COM", "AQAAAAEAACcQAAAAEIEd3+QygN7GSnkFJ8/goq9nRMn4mh4y4x0ig/9whnNrZ+sBK5N3L8dNFQ9tfGvUCQ==", null, false, "InstructorSeed", false, "MyInstructor@Test.com" },
                    { 4, 0, true, "bbe8a6ab-e3d4-4f71-8d8a-20ff3c244352", 2, "MyAdmin@Test.com", true, "My", "Admin", false, null, "MYADMIN@TEST.COM", "MYADMIN@TEST.COM", "AQAAAAEAACcQAAAAEJFRpMH/b2Pfd1dvvMrWNwZUJ/Sn8o3zsAIZO8u0sxMQ1Tdu0XFRb+sup28BmlC6Nw==", null, false, "AdminSeed", false, "MyAdmin@Test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { 5, 2, "EmployeeRole" },
                    { 2, 5, "EmployeeRole" },
                    { 4, 3, "EmployeeRole" },
                    { 3, 4, "EmployeeRole" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "ID", "EmployeeID", "DateOfCreation", "DepartmentID", "Description", "EndDate", "StartDate", "TicketNumber", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), 1, "My First Ticket", null, null, "A220402001", "My First Ticket Title" },
                    { 2, 2, new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), 1, "My Second Ticket", null, null, "A220402002", "My Second Ticket Title" },
                    { 3, 3, new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), 2, "My Third Ticket", null, null, "E220402001", "My Third Ticket Title" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "ID", "EmployeeID", "DateOfCreation", "DepartmentID", "Description", "EndDate", "Priority", "StartDate", "Status", "TicketNumber", "Title" },
                values: new object[,]
                {
                    { 4, 3, new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), 3, "My Fourth Ticket", null, 1, null, 2, "220402001", "My Fourth Ticket Title" },
                    { 5, 4, new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698), 4, "My Fifth Ticket", null, 2, null, 1, "I220402001", "My Fifth Ticket Title" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "EmployeeID", "Content", "DateOfCreation", "TicketID" },
                values: new object[,]
                {
                    { 1, 2, "This is a test. Ignore.", new DateTime(2022, 4, 2, 16, 48, 10, 725, DateTimeKind.Local).AddTicks(9861), 1 },
                    { 2, 3, "This is a test response. Ignore.", new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(196), 1 },
                    { 3, 4, "Another test. Ignore.", new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(205), 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTickets",
                columns: new[] { "EmployeeID", "TicketID", "DateAssigned" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EmployeeID",
                table: "Comments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TicketID",
                table: "Comments",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Prefix",
                table: "Departments",
                column: "Prefix",
                unique: true,
                filter: "[Prefix] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTickets_TicketID",
                table: "EmployeeTickets",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentID",
                table: "Tickets",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeID",
                table: "Tickets",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketNumber",
                table: "Tickets",
                column: "TicketNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EmployeeTickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

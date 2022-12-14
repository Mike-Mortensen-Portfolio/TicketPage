// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SKP.TicketPage.Domain;

namespace SKP.TicketPage.Domain.Migrations
{
    [DbContext(typeof(TicketPageContext))]
    [Migration("20220402144811_v031603")]
    partial class v031603
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1225)
                        .HasColumnType("nvarchar(1225)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("TicketID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 2,
                            Content = "This is a test. Ignore.",
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 725, DateTimeKind.Local).AddTicks(9861),
                            TicketID = 1
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 3,
                            Content = "This is a test response. Ignore.",
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(196),
                            TicketID = 1
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 4,
                            Content = "Another test. Ignore.",
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 726, DateTimeKind.Local).AddTicks(205),
                            TicketID = 2
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prefix")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("ID");

                    b.HasIndex("Prefix")
                        .IsUnique()
                        .HasFilter("[Prefix] IS NOT NULL");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Automatik",
                            Prefix = "A"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Elektriker",
                            Prefix = "E"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Elektronik",
                            Prefix = ""
                        },
                        new
                        {
                            ID = 4,
                            Name = "ITM",
                            Prefix = "I"
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Active = false,
                            ConcurrencyStamp = "d7ad7a4d-7558-4a3a-8fb4-ab8d1076c85c",
                            EmailConfirmed = false,
                            FirstName = "System",
                            LastName = "",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SystemSeed",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Active = true,
                            ConcurrencyStamp = "8392c44e-4a25-45ff-87a8-687d48ab8614",
                            DepartmentID = 1,
                            Email = "MyDeveloper@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Developer",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYDEVELOPER@TEST.COM",
                            NormalizedUserName = "MYDEVELOPER@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHAYXIcLpdP2Zy8kOCqdAdYsKTsLu7f0d79js1Fzl5HX+S0dH0rplO0FDtO5RM5GxA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "DeveloperSeed",
                            TwoFactorEnabled = false,
                            UserName = "MyDeveloper@Test.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Active = true,
                            ConcurrencyStamp = "d1273483-d962-4839-9936-e535b83996f2",
                            DepartmentID = 2,
                            Email = "MyInstructor@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Instructor",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYINSTRUCTOR@TEST.COM",
                            NormalizedUserName = "MYINSTRUCTOR@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIEd3+QygN7GSnkFJ8/goq9nRMn4mh4y4x0ig/9whnNrZ+sBK5N3L8dNFQ9tfGvUCQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "InstructorSeed",
                            TwoFactorEnabled = false,
                            UserName = "MyInstructor@Test.com"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            Active = true,
                            ConcurrencyStamp = "bbe8a6ab-e3d4-4f71-8d8a-20ff3c244352",
                            DepartmentID = 2,
                            Email = "MyAdmin@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYADMIN@TEST.COM",
                            NormalizedUserName = "MYADMIN@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJFRpMH/b2Pfd1dvvMrWNwZUJ/Sn8o3zsAIZO8u0sxMQ1Tdu0XFRb+sup28BmlC6Nw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "AdminSeed",
                            TwoFactorEnabled = false,
                            UserName = "MyAdmin@Test.com"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            Active = true,
                            ConcurrencyStamp = "af15fcf5-988c-4ffc-a60e-4ff8669f4bcf",
                            DepartmentID = 1,
                            Email = "MyUser@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYUSER@TEST.COM",
                            NormalizedUserName = "MYUSER@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJZNseFnbyngGPrgaISU9xKtFAlLjwjt1vF2mXzCSRasqgOwy9pjk6LeiSsj0iagJw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "UserSeed",
                            TwoFactorEnabled = false,
                            UserName = "MyUser@Test.com"
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.EmployeeTicket", b =>
                {
                    b.Property<int>("AssignedEmployeeID")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignedEmployeeID", "TicketID");

                    b.HasIndex("TicketID");

                    b.ToTable("EmployeeTickets");

                    b.HasData(
                        new
                        {
                            AssignedEmployeeID = 3,
                            TicketID = 1,
                            DateAssigned = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AssignedEmployeeID = 2,
                            TicketID = 1,
                            DateAssigned = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "8cf8945d-c45c-4df1-b3e1-ae5a13c0646f",
                            Description = "A system role used to provide auto content",
                            DisplayName = "System",
                            Name = "System",
                            NormalizedName = "SYSTEM"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "09d130c8-ef7a-4443-ac96-d3237907d87f",
                            Description = "No elevated permissions",
                            DisplayName = "Normal",
                            Name = "Base",
                            NormalizedName = "BASE"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "0dc1210b-b421-4b3f-aeb8-045b9b4ce74e",
                            Description = "Adminsitrator access to the system",
                            DisplayName = "Admin",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "88aead10-7bc1-400e-a701-aae84fae2281",
                            Description = "Super user with access to the entire system",
                            DisplayName = "Instruktør",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        },
                        new
                        {
                            Id = 5,
                            ConcurrencyStamp = "ddd576cf-c2bb-4b87-bd17-dfb9d95ba721",
                            Description = "Deep access to internal data",
                            DisplayName = "Udvikler",
                            Name = "Developer",
                            NormalizedName = "DEVELOPER"
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2450)
                        .HasColumnType("nvarchar(2450)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("TicketNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("TicketNumber")
                        .IsUnique();

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 2,
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698),
                            DepartmentID = 1,
                            Description = "My First Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "A220402001",
                            Title = "My First Ticket Title"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 2,
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698),
                            DepartmentID = 1,
                            Description = "My Second Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "A220402002",
                            Title = "My Second Ticket Title"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 3,
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698),
                            DepartmentID = 2,
                            Description = "My Third Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "E220402001",
                            Title = "My Third Ticket Title"
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = 3,
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698),
                            DepartmentID = 3,
                            Description = "My Fourth Ticket",
                            Priority = 1,
                            Status = 2,
                            TicketNumber = "220402001",
                            Title = "My Fourth Ticket Title"
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = 4,
                            DateOfCreation = new DateTime(2022, 4, 2, 16, 48, 10, 722, DateTimeKind.Local).AddTicks(698),
                            DepartmentID = 4,
                            Description = "My Fifth Ticket",
                            Priority = 2,
                            Status = 1,
                            TicketNumber = "I220402001",
                            Title = "My Fifth Ticket Title"
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.EmployeeRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<int>");

                    b.HasDiscriminator().HasValue("EmployeeRole");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 5
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 4
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Comment", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SKP.TicketPage.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Employee", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.EmployeeTicket", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", "AssignedEmployee")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("AssignedEmployeeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SKP.TicketPage.Domain.Entities.Ticket", "Ticket")
                        .WithMany("AssignedEmployees")
                        .HasForeignKey("TicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedEmployee");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("SKP.TicketPage.Domain.Entities.Employee", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SKP.TicketPage.Domain.Entities.Department", "Department")
                        .WithMany("Tickets")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Employee", b =>
                {
                    b.Navigation("AssignedTickets");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Ticket", b =>
                {
                    b.Navigation("AssignedEmployees");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}

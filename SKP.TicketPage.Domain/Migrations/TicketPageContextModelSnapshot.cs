﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SKP.TicketPage.Domain;

namespace SKP.TicketPage.Domain.Migrations
{
    [DbContext(typeof(TicketPageContext))]
    partial class TicketPageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 751, DateTimeKind.Local).AddTicks(972),
                            TicketID = 1
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 3,
                            Content = "This is a test response. Ignore.",
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 751, DateTimeKind.Local).AddTicks(1284),
                            TicketID = 1
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 4,
                            Content = "Another test. Ignore.",
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 751, DateTimeKind.Local).AddTicks(1292),
                            TicketID = 2
                        });
                });

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IncludePrefix")
                        .HasColumnType("bit");

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
                            IncludePrefix = true,
                            Name = "Automatik",
                            Prefix = "A"
                        },
                        new
                        {
                            ID = 2,
                            IncludePrefix = true,
                            Name = "Elektriker",
                            Prefix = "E"
                        },
                        new
                        {
                            ID = 3,
                            IncludePrefix = false,
                            Name = "Elektronik",
                            Prefix = "EL"
                        },
                        new
                        {
                            ID = 4,
                            IncludePrefix = true,
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                            ConcurrencyStamp = "1ef14777-8891-4ccd-8f2e-3c3c088335b5",
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
                            ConcurrencyStamp = "c315904e-6a8a-45ea-ae56-e9225c07cc8d",
                            DepartmentID = 1,
                            Email = "MyDeveloper@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Developer",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYDEVELOPER@TEST.COM",
                            NormalizedUserName = "MYDEVELOPER@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKqCuTgNNCUxAseb+q6qzirplLgbi+ts2VMaRvHB1XnCOuGg0O1GgrBJ/e9+2x62UA==",
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
                            ConcurrencyStamp = "c72638b2-dd6a-4fbb-aeda-bdf9c7f10aef",
                            DepartmentID = 2,
                            Email = "MyInstructor@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Instructor",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYINSTRUCTOR@TEST.COM",
                            NormalizedUserName = "MYINSTRUCTOR@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJGFgetpjVLraw8j884ruDVev1bdNLMaDGD2Jyf3VHRMJWyyImMYuPiAQsm1DAu4fA==",
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
                            ConcurrencyStamp = "dd569cd3-3b49-4e74-8867-9d62f23eea4a",
                            DepartmentID = 2,
                            Email = "MyAdmin@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYADMIN@TEST.COM",
                            NormalizedUserName = "MYADMIN@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEModC4BZkVJHrrZsB0DO0RCkn9UvGUc3mJJbnYILQ6tea3m+aA/TIhfomW8y/a1cWg==",
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
                            ConcurrencyStamp = "3dddac94-3b9c-42c1-ac4f-c15de57effa7",
                            DepartmentID = 1,
                            Email = "MyUser@Test.com",
                            EmailConfirmed = true,
                            FirstName = "My",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "MYUSER@TEST.COM",
                            NormalizedUserName = "MYUSER@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJVnA7glpfkTp6Dv1zkTIoNZbj2NdMM7XkbDMDjb/4rEtbjanzYBK9nW9D1uNqyYbw==",
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

            modelBuilder.Entity("SKP.TicketPage.Domain.Entities.LogEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.Property<string>("RequestID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeverityFlag")
                        .HasColumnType("int");

                    b.Property<string>("StackTrace")
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.HasKey("ID");

                    b.ToTable("LogEntries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LogDate = new DateTime(2022, 5, 21, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            Message = "My Critical Log",
                            RequestID = "220521",
                            SeverityFlag = 0
                        },
                        new
                        {
                            ID = 2,
                            LogDate = new DateTime(2022, 5, 23, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            Message = "My Info Log 2",
                            RequestID = "220523",
                            SeverityFlag = 2
                        },
                        new
                        {
                            ID = 3,
                            LogDate = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            Message = "My Warning Log 3",
                            RequestID = "220525",
                            SeverityFlag = 1
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
                            ConcurrencyStamp = "01cf4402-6cf0-4b14-9256-d9ae74649d9a",
                            Description = "A system role used to provide auto content",
                            DisplayName = "System",
                            Name = "System",
                            NormalizedName = "SYSTEM"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "82040ea4-e0ea-43a2-9d7e-5f4fa39fde6d",
                            Description = "No elevated permissions",
                            DisplayName = "Normal",
                            Name = "Base",
                            NormalizedName = "BASE"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "2ec60c00-104a-42df-917c-dd5bd13e5e65",
                            Description = "Adminsitrator access to the system",
                            DisplayName = "Admin",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "33dd177e-c1bd-4b6b-9f8c-ab551837de95",
                            Description = "Super user with access to the entire system",
                            DisplayName = "Instruktør",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        },
                        new
                        {
                            Id = 5,
                            ConcurrencyStamp = "beba1154-d33b-4eec-aac9-76a521ae24b4",
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
                        .HasDefaultValue(0);

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
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            DepartmentID = 1,
                            Description = "My First Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "A220525001",
                            Title = "My First Ticket Title"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 2,
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            DepartmentID = 1,
                            Description = "My Second Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "A220525002",
                            Title = "My Second Ticket Title"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 3,
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            DepartmentID = 2,
                            Description = "My Third Ticket",
                            Priority = 0,
                            Status = 0,
                            TicketNumber = "E220525001",
                            Title = "My Third Ticket Title"
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = 3,
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            DepartmentID = 3,
                            Description = "My Fourth Ticket",
                            Priority = 1,
                            Status = 2,
                            TicketNumber = "220525001",
                            Title = "My Fourth Ticket Title"
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = 4,
                            DateOfCreation = new DateTime(2022, 5, 25, 15, 59, 39, 747, DateTimeKind.Local).AddTicks(559),
                            DepartmentID = 4,
                            Description = "My Fifth Ticket",
                            Priority = 2,
                            Status = 1,
                            TicketNumber = "I220525001",
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
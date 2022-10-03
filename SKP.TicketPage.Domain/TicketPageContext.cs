using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SKP.TicketPage.Domain.Entities;
using System;

namespace SKP.TicketPage.Domain
{
    /// <summary>
    /// The none restricted, <strong>direct</strong> connection to DB. <strong>Only</strong> use within domain- and servicelayer!
    /// </summary>
    public class TicketPageContext : IdentityDbContext<Employee, Role, int>
    {
        public TicketPageContext()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .OnDelete(DeleteBehavior.SetNull);  //  Severing the relationship to employees when a department is deleted.

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Prefix)
                .IsUnique();    //  Marking Department Prefix as unique to avoid Ticket Number collisions
            #endregion

            #region Ticket
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Priority)
                .HasDefaultValue(Ticket.TicketPriority.Normal); //  Ensuring that all tickets are raised with normal priority if no other priority is specified

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Status)
                .HasDefaultValue(Ticket.TicketStatus.Inbound);  //  Ensuring that the status of newly raised tickets are inbound if no other value is specified

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.TicketNumber)
                .IsUnique();    //  Marking Ticket Number as unique to avoid collisions
            #endregion

            #region Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .OnDelete(DeleteBehavior.NoAction); //  Disabling the cascading behavior for authors of comments to ensure users are not deleted upon comment removal
            #endregion

            #region EmployeeTicket
            modelBuilder.Entity<EmployeeTicket>()
                .HasOne(et => et.AssignedEmployee)
                .WithMany(e => e.AssignedTickets)
                .OnDelete(DeleteBehavior.NoAction); //  Disabling the cascading behavior for assigned employees of tickets to ensure users are not deleted upon ticket removal
            #endregion

            #region Combined keys
            modelBuilder.Entity<EmployeeTicket>()
                .HasKey(et => new { et.AssignedEmployeeID, et.TicketID });  //  Join table with combined [AssignedEmployeeID] and [TicketID]
            #endregion

            #region Seed Data
            var normalizer = new UpperInvariantLookupNormalizer();
            var hasher = new PasswordHasher<Employee>();

            modelBuilder.Entity<Department>().HasData(
                new Department { ID = 1, Name = "Automatik", Prefix = "A", IncludePrefix = true },
                new Department { ID = 2, Name = "Elektriker", Prefix = "E", IncludePrefix = true },
                new Department { ID = 3, Name = "Elektronik", Prefix = "EL", IncludePrefix = false },
                new Department { ID = 4, Name = "ITM", Prefix = "I", IncludePrefix = true }
                );

            #region Role Seed
            var systemRole = new Role { Id = 1, Name = "System", DisplayName = "System", Description = "A system role used to provide auto content" };
            systemRole.NormalizedName = normalizer.NormalizeName(systemRole.Name);

            var baseRole = new Role { Id = 2, Name = "Base", DisplayName = "Normal", Description = "No elevated permissions" };
            baseRole.NormalizedName = normalizer.NormalizeName(baseRole.Name);

            var adminRole = new Role { Id = 3, Name = "Admin", DisplayName = "Admin", Description = "Adminsitrator access to the system" };
            adminRole.NormalizedName = normalizer.NormalizeName(adminRole.Name);

            var instructorRole = new Role { Id = 4, Name = "Instructor", DisplayName = "Instruktør", Description = "Super user with access to the entire system" };
            instructorRole.NormalizedName = normalizer.NormalizeName(instructorRole.Name);

            var developerRole = new Role { Id = 5, Name = "Developer", DisplayName = "Udvikler", Description = "Deep access to internal data" };
            developerRole.NormalizedName = normalizer.NormalizeName(developerRole.Name);

            modelBuilder.Entity<Role>().HasData(
                systemRole,
                baseRole,
                adminRole,
                instructorRole,
                developerRole
                );
            #endregion

            #region User Seed
            var systemUser = new Employee { Id = 1, Active = false, FirstName = "System", LastName = "" };
            systemUser.NormalizedUserName = normalizer.NormalizeName(systemUser.UserName);
            systemUser.SecurityStamp = "SystemSeed";

            var developer = new Employee { Id = 2, Active = true, DepartmentID = 1, Email = "MyDeveloper@Test.com", FirstName = "My", LastName = "Developer", UserName = "MyDeveloper@Test.com", EmailConfirmed = true };
            developer.PasswordHash = hasher.HashPassword(developer, "P@ssw0rd");
            developer.NormalizedEmail = normalizer.NormalizeEmail(developer.Email);
            developer.NormalizedUserName = normalizer.NormalizeName(developer.UserName);
            developer.SecurityStamp = "DeveloperSeed";

            var instructor = new Employee { Id = 3, Active = true, DepartmentID = 2, Email = "MyInstructor@Test.com", FirstName = "My", LastName = "Instructor", UserName = "MyInstructor@Test.com", EmailConfirmed = true };
            instructor.PasswordHash = hasher.HashPassword(instructor, "P@ssw0rd");
            instructor.NormalizedEmail = normalizer.NormalizeEmail(instructor.Email);
            instructor.NormalizedUserName = normalizer.NormalizeName(instructor.UserName);
            instructor.SecurityStamp = "InstructorSeed";

            var admin = new Employee { Id = 4, Active = true, DepartmentID = 2, Email = "MyAdmin@Test.com", FirstName = "My", LastName = "Admin", UserName = "MyAdmin@Test.com", EmailConfirmed = true };
            admin.PasswordHash = hasher.HashPassword(admin, "P@ssw0rd");
            admin.NormalizedEmail = normalizer.NormalizeEmail(admin.Email);
            admin.NormalizedUserName = normalizer.NormalizeName(admin.UserName);
            admin.SecurityStamp = "AdminSeed";

            var user = new Employee { Id = 5, Active = true, DepartmentID = 1, Email = "MyUser@Test.com", FirstName = "My", LastName = "User", UserName = "MyUser@Test.com", EmailConfirmed = true };
            user.PasswordHash = hasher.HashPassword(user, "P@ssw0rd");
            user.NormalizedEmail = normalizer.NormalizeEmail(user.Email);
            user.NormalizedUserName = normalizer.NormalizeName(user.UserName);
            user.SecurityStamp = "UserSeed";

            modelBuilder.Entity<Employee>().HasData(
                systemUser,
                developer,
                instructor,
                admin,
                user
                );
            #endregion

            modelBuilder.Entity<EmployeeRole>().HasData(
                new EmployeeRole { RoleId = 1, UserId = 1 },
                new EmployeeRole { RoleId = 5, UserId = 2 },
                new EmployeeRole { RoleId = 4, UserId = 3 },
                new EmployeeRole { RoleId = 3, UserId = 4 },
                new EmployeeRole { RoleId = 2, UserId = 5 }
                );

            DateTime now = DateTime.Now;
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { ID = 1, TicketNumber = $"A{now:yyMMdd}001", AuthorID = 2, DateOfCreation = now, DepartmentID = 1, Description = "My First Ticket", Title = "My First Ticket Title" },
                new Ticket { ID = 2, TicketNumber = $"A{now:yyMMdd}002", AuthorID = 2, DateOfCreation = now, DepartmentID = 1, Description = "My Second Ticket", Title = "My Second Ticket Title" },
                new Ticket { ID = 3, TicketNumber = $"E{now:yyMMdd}001", AuthorID = 3, DateOfCreation = now, DepartmentID = 2, Description = "My Third Ticket", Title = "My Third Ticket Title" },
                new Ticket { ID = 4, TicketNumber = $"{now:yyMMdd}001", AuthorID = 3, DateOfCreation = now, DepartmentID = 3, Description = "My Fourth Ticket", Title = "My Fourth Ticket Title", Priority = Ticket.TicketPriority.Important, Status = Ticket.TicketStatus.Pending },
                new Ticket { ID = 5, TicketNumber = $"I{now:yyMMdd}001", AuthorID = 4, DateOfCreation = now, DepartmentID = 4, Description = "My Fifth Ticket", Title = "My Fifth Ticket Title", Priority = Ticket.TicketPriority.Critical, Status = Ticket.TicketStatus.Ongoing }
                );

            modelBuilder.Entity<EmployeeTicket>().HasData(
                new EmployeeTicket { AssignedEmployeeID = 3, TicketID = 1 },
                new EmployeeTicket { AssignedEmployeeID = 2, TicketID = 1 }
                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { ID = 1, AuthorID = 2, TicketID = 1, DateOfCreation = DateTime.Now, Content = "This is a test. Ignore." },
                new Comment { ID = 2, AuthorID = 3, TicketID = 1, DateOfCreation = DateTime.Now, Content = "This is a test response. Ignore." },
                new Comment { ID = 3, AuthorID = 4, TicketID = 2, DateOfCreation = DateTime.Now, Content = "Another test. Ignore." }
                );

            // Variable now is declared in another region
            modelBuilder.Entity<LogEntry>().HasData(
                new LogEntry { ID = 1, LogDate = now.AddDays(-4), RequestID = $"{now.AddDays(-4):yyMMdd}001", Message = "My Critical Log", SeverityFlag = LogEntry.Severity.Critical },
                new LogEntry { ID = 2, LogDate = now.AddDays(-2), RequestID = $"{now.AddDays(-2):yyMMdd}002", Message = "My Info Log 2", SeverityFlag = LogEntry.Severity.Info },
                new LogEntry { ID = 3, LogDate = now, RequestID = $"{now:yyMMdd}003", Message = "My Warning Log 3", SeverityFlag = LogEntry.Severity.Warning }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

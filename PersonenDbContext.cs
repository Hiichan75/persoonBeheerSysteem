using Microsoft.EntityFrameworkCore;
using persoonBeheerSysteem.Models;
using System;

namespace personBeheerSysteem.Data
{
    public class PersonenDbContext : DbContext
    {
        public PersonenDbContext(DbContextOptions<PersonenDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Absence> Absences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonenDbDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;",
                                             sqlOptions => sqlOptions.EnableRetryOnFailure()); // Enables retry on transient failures
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<Absence>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Absences)
                .HasForeignKey(a => a.EmployeeID);

            // Specify precision for Salary column to avoid truncation
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "HR" },
                new Department { DepartmentID = 2, DepartmentName = "Finance" },
                new Department { DepartmentID = 3, DepartmentName = "IT" },
                new Department { DepartmentID = 4, DepartmentName = "Marketing" },
                new Department { DepartmentID = 5, DepartmentName = "Operations" },
                new Department { DepartmentID = 6, DepartmentName = "Customer Service" },
                new Department { DepartmentID = 7, DepartmentName = "Sales" },
                new Department { DepartmentID = 8, DepartmentName = "Research" },
                new Department { DepartmentID = 9, DepartmentName = "Procurement" },
                new Department { DepartmentID = 10, DepartmentName = "Legal" }
            );

            // Seeding Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Name = "John Doe", ContactInfo = "john.doe@example.com", Salary = 50000, DepartmentID = 1 },
                new Employee { EmployeeID = 2, Name = "Jane Smith", ContactInfo = "jane.smith@example.com", Salary = 60000, DepartmentID = 2 },
                new Employee { EmployeeID = 3, Name = "Alice Johnson", ContactInfo = "alice.johnson@example.com", Salary = 45000, DepartmentID = 3 },
                new Employee { EmployeeID = 4, Name = "Bob Brown", ContactInfo = "bob.brown@example.com", Salary = 48000, DepartmentID = 4 },
                new Employee { EmployeeID = 5, Name = "Charlie White", ContactInfo = "charlie.white@example.com", Salary = 70000, DepartmentID = 1 },
                new Employee { EmployeeID = 6, Name = "Emily Green", ContactInfo = "emily.green@example.com", Salary = 54000, DepartmentID = 5 },
                new Employee { EmployeeID = 7, Name = "Frank Black", ContactInfo = "frank.black@example.com", Salary = 52000, DepartmentID = 6 },
                new Employee { EmployeeID = 8, Name = "Grace Blue", ContactInfo = "grace.blue@example.com", Salary = 49000, DepartmentID = 7 },
                new Employee { EmployeeID = 9, Name = "Henry Silver", ContactInfo = "henry.silver@example.com", Salary = 53000, DepartmentID = 8 },
                new Employee { EmployeeID = 10, Name = "Isabella Gold", ContactInfo = "isabella.gold@example.com", Salary = 58000, DepartmentID = 9 }
            );

            // Seeding Absences
            modelBuilder.Entity<Absence>().HasData(
                new Absence { AbsenceID = 1, EmployeeID = 1, Date = DateTime.Now.AddDays(-7), Reason = "Sick Leave" },
                new Absence { AbsenceID = 2, EmployeeID = 2, Date = DateTime.Now.AddDays(-5), Reason = "Vacation" },
                new Absence { AbsenceID = 3, EmployeeID = 3, Date = DateTime.Now.AddDays(-10), Reason = "Family Emergency" },
                new Absence { AbsenceID = 4, EmployeeID = 4, Date = DateTime.Now.AddDays(-3), Reason = "Medical Appointment" },
                new Absence { AbsenceID = 5, EmployeeID = 5, Date = DateTime.Now.AddDays(-2), Reason = "Work From Home" },
                new Absence { AbsenceID = 6, EmployeeID = 6, Date = DateTime.Now.AddDays(-1), Reason = "Conference" },
                new Absence { AbsenceID = 7, EmployeeID = 7, Date = DateTime.Now.AddDays(-4), Reason = "Vacation" },
                new Absence { AbsenceID = 8, EmployeeID = 8, Date = DateTime.Now.AddDays(-6), Reason = "Sick Leave" },
                new Absence { AbsenceID = 9, EmployeeID = 9, Date = DateTime.Now.AddDays(-8), Reason = "Training" },
                new Absence { AbsenceID = 10, EmployeeID = 10, Date = DateTime.Now.AddDays(-9), Reason = "Client Meeting" }
            );
        }
    }
}

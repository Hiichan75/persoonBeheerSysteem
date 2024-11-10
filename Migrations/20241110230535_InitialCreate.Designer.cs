﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using personBeheerSysteem.Data;

#nullable disable

namespace persoonBeheerSysteem.Migrations
{
    [DbContext(typeof(PersonenDbContext))]
    [Migration("20241110230535_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbsenceID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Absences", (string)null);

                    b.HasData(
                        new
                        {
                            AbsenceID = 1,
                            Date = new DateTime(2024, 11, 4, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1034),
                            EmployeeID = 1,
                            Reason = "Sick Leave"
                        },
                        new
                        {
                            AbsenceID = 2,
                            Date = new DateTime(2024, 11, 6, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1083),
                            EmployeeID = 2,
                            Reason = "Vacation"
                        },
                        new
                        {
                            AbsenceID = 3,
                            Date = new DateTime(2024, 11, 1, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1085),
                            EmployeeID = 3,
                            Reason = "Family Emergency"
                        },
                        new
                        {
                            AbsenceID = 4,
                            Date = new DateTime(2024, 11, 8, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1087),
                            EmployeeID = 4,
                            Reason = "Medical Appointment"
                        },
                        new
                        {
                            AbsenceID = 5,
                            Date = new DateTime(2024, 11, 9, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1089),
                            EmployeeID = 5,
                            Reason = "Work From Home"
                        },
                        new
                        {
                            AbsenceID = 6,
                            Date = new DateTime(2024, 11, 10, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1090),
                            EmployeeID = 6,
                            Reason = "Conference"
                        },
                        new
                        {
                            AbsenceID = 7,
                            Date = new DateTime(2024, 11, 7, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1092),
                            EmployeeID = 7,
                            Reason = "Vacation"
                        },
                        new
                        {
                            AbsenceID = 8,
                            Date = new DateTime(2024, 11, 5, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1094),
                            EmployeeID = 8,
                            Reason = "Sick Leave"
                        },
                        new
                        {
                            AbsenceID = 9,
                            Date = new DateTime(2024, 11, 3, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1095),
                            EmployeeID = 9,
                            Reason = "Training"
                        },
                        new
                        {
                            AbsenceID = 10,
                            Date = new DateTime(2024, 11, 2, 0, 5, 35, 414, DateTimeKind.Local).AddTicks(1097),
                            EmployeeID = 10,
                            Reason = "Client Meeting"
                        });
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartmentID = 2,
                            DepartmentName = "Finance"
                        },
                        new
                        {
                            DepartmentID = 3,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            DepartmentID = 4,
                            DepartmentName = "Marketing"
                        },
                        new
                        {
                            DepartmentID = 5,
                            DepartmentName = "Operations"
                        },
                        new
                        {
                            DepartmentID = 6,
                            DepartmentName = "Customer Service"
                        },
                        new
                        {
                            DepartmentID = 7,
                            DepartmentName = "Sales"
                        },
                        new
                        {
                            DepartmentID = 8,
                            DepartmentName = "Research"
                        },
                        new
                        {
                            DepartmentID = 9,
                            DepartmentName = "Procurement"
                        },
                        new
                        {
                            DepartmentID = 10,
                            DepartmentName = "Legal"
                        });
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            ContactInfo = "john.doe@example.com",
                            DepartmentID = 1,
                            Name = "John Doe",
                            Salary = 50000m
                        },
                        new
                        {
                            EmployeeID = 2,
                            ContactInfo = "jane.smith@example.com",
                            DepartmentID = 2,
                            Name = "Jane Smith",
                            Salary = 60000m
                        },
                        new
                        {
                            EmployeeID = 3,
                            ContactInfo = "alice.johnson@example.com",
                            DepartmentID = 3,
                            Name = "Alice Johnson",
                            Salary = 45000m
                        },
                        new
                        {
                            EmployeeID = 4,
                            ContactInfo = "bob.brown@example.com",
                            DepartmentID = 4,
                            Name = "Bob Brown",
                            Salary = 48000m
                        },
                        new
                        {
                            EmployeeID = 5,
                            ContactInfo = "charlie.white@example.com",
                            DepartmentID = 1,
                            Name = "Charlie White",
                            Salary = 70000m
                        },
                        new
                        {
                            EmployeeID = 6,
                            ContactInfo = "emily.green@example.com",
                            DepartmentID = 5,
                            Name = "Emily Green",
                            Salary = 54000m
                        },
                        new
                        {
                            EmployeeID = 7,
                            ContactInfo = "frank.black@example.com",
                            DepartmentID = 6,
                            Name = "Frank Black",
                            Salary = 52000m
                        },
                        new
                        {
                            EmployeeID = 8,
                            ContactInfo = "grace.blue@example.com",
                            DepartmentID = 7,
                            Name = "Grace Blue",
                            Salary = 49000m
                        },
                        new
                        {
                            EmployeeID = 9,
                            ContactInfo = "henry.silver@example.com",
                            DepartmentID = 8,
                            Name = "Henry Silver",
                            Salary = 53000m
                        },
                        new
                        {
                            EmployeeID = 10,
                            ContactInfo = "isabella.gold@example.com",
                            DepartmentID = 9,
                            Name = "Isabella Gold",
                            Salary = 58000m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Absence", b =>
                {
                    b.HasOne("persoonBeheerSysteem.Models.Employee", "Employee")
                        .WithMany("Absences")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Employee", b =>
                {
                    b.HasOne("persoonBeheerSysteem.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("persoonBeheerSysteem.Models.Employee", b =>
                {
                    b.Navigation("Absences");
                });
#pragma warning restore 612, 618
        }
    }
}
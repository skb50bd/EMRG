﻿// <auto-generated />
using System;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190402135711_section_seats")]
    partial class section_seats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentId");

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MetaId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.CourseEnrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade");

                    b.Property<float>("GradePoint");

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<int>("SectionId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("MetaId");

                    b.HasIndex("SectionId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseEnrollment");
                });

            modelBuilder.Entity("Domain.CoursePrerequisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("PrerequisiteId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PrerequisiteId");

                    b.ToTable("CoursePrerequisite");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MetaId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Designation");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Initial");

                    b.Property<bool>("IsRemoved");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("MetaId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MetaId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Domain.Metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("Domain.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<int>("DepartmentId");

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<string>("Name");

                    b.Property<string>("RequiredCredits");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MetaId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Domain.ProgramCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<bool>("IsOptional");

                    b.Property<int>("ProgramId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramCourse");
                });

            modelBuilder.Entity("Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MetaId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Domain.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("FacultyId");

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<int>("Number");

                    b.Property<int>("RoomId");

                    b.Property<int>("Seat");

                    b.Property<int>("SemesterId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MetaId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRemoved");

                    b.Property<int?>("MetaId");

                    b.Property<int>("Season");

                    b.Property<int>("Year");

                    b.Property<bool>("hasEnded");

                    b.Property<bool>("hasStarted");

                    b.HasKey("Id");

                    b.HasAlternateKey("Season", "Year");

                    b.HasIndex("MetaId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsRemoved");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("MetaId");

                    b.Property<string>("Phone");

                    b.Property<int>("ProgramId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MetaId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("DepartmentId");

                    b.Property<int>("Role");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.CourseEnrollment", b =>
                {
                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");

                    b.HasOne("Domain.Section", "Section")
                        .WithMany("Enrollments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.CoursePrerequisite", b =>
                {
                    b.HasOne("Domain.Course", "Course")
                        .WithMany("Prerequisites")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Course", "Prerequisite")
                        .WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Faculties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.Program", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Programs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.ProgramCourse", b =>
                {
                    b.HasOne("Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Program", "Program")
                        .WithMany("Courses")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Room", b =>
                {
                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.Section", b =>
                {
                    b.HasOne("Domain.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Faculty", "Faculty")
                        .WithMany("Sections")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");

                    b.HasOne("Domain.Room", "Room")
                        .WithMany("Sections")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Domain.Schedule", "Schedule", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("IsRemoved");

                            b1.HasKey("Id");

                            b1.ToTable("Sections");

                            b1.HasOne("Domain.Section")
                                .WithOne("Schedule")
                                .HasForeignKey("Domain.Schedule", "Id")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsMany("Domain.TimeSlot", "TimeSlots", b2 =>
                                {
                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<int>("DayOfWeek");

                                    b2.Property<DateTime>("EndTime");

                                    b2.Property<int>("ScheduleId");

                                    b2.Property<DateTime>("StartTime");

                                    b2.HasKey("Id");

                                    b2.HasIndex("ScheduleId");

                                    b2.ToTable("TimeSlot");

                                    b2.HasOne("Domain.Schedule")
                                        .WithMany("TimeSlots")
                                        .HasForeignKey("ScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Metadata", "Meta")
                        .WithMany()
                        .HasForeignKey("MetaId");

                    b.HasOne("Domain.Program", "Program")
                        .WithMany("Students")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Domain.StudentId", "StudentId", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Program");

                            b1.Property<int>("Roll");

                            b1.Property<int>("Season");

                            b1.Property<int>("Year");

                            b1.HasKey("Id");

                            b1.ToTable("Students");

                            b1.HasOne("Domain.Student")
                                .WithOne("StudentId")
                                .HasForeignKey("Domain.StudentId", "Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryPatternWithUOW.EF;

#nullable disable

namespace RepositoryPatternWithUOW.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241217115242_AddingRoleModelWithAuth")]
    partial class AddingRoleModelWithAuth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("ArrivingTime")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("LateTimeHours")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("LeavingTime")
                        .HasColumnType("time");

                    b.Property<int>("OverTimeHours")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly?>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<DateOnly?>("ContractDate")
                        .HasColumnType("date");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<TimeOnly?>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.OfficialHoliday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfficialHolidays");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.SpecialLeave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SpecialLeaves");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Attendance", b =>
                {
                    b.HasOne("RepositoryPatternWithUOW.Core.Models.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Employee", b =>
                {
                    b.HasOne("RepositoryPatternWithUOW.Core.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("RepositoryPatternWithUOW.Core.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.SpecialLeave", b =>
                {
                    b.HasOne("RepositoryPatternWithUOW.Core.Models.Employee", "Employee")
                        .WithMany("SpecialLeaves")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("SpecialLeaves");
                });

            modelBuilder.Entity("RepositoryPatternWithUOW.Core.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

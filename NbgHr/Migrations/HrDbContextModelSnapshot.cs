﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NbgHr.Model;

namespace NbgHr.Migrations
{
    [DbContext(typeof(HrDbContext))]
    partial class HrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NbgHr.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("NbgHr.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BelongingDepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpolyeeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MaritalStatus")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<int>("Speciality")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BelongingDepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NbgHr.Model.Department", b =>
                {
                    b.HasOne("NbgHr.Model.Employee", "Manager")
                        .WithOne("ManagingDepartment")
                        .HasForeignKey("NbgHr.Model.Department", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("NbgHr.Model.Employee", b =>
                {
                    b.HasOne("NbgHr.Model.Department", "BelongingDepartment")
                        .WithMany("Employees")
                        .HasForeignKey("BelongingDepartmentId");

                    b.Navigation("BelongingDepartment");
                });

            modelBuilder.Entity("NbgHr.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NbgHr.Model.Employee", b =>
                {
                    b.Navigation("ManagingDepartment");
                });
#pragma warning restore 612, 618
        }
    }
}
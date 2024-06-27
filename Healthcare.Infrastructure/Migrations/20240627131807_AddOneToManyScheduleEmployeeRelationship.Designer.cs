﻿// <auto-generated />
using System;
using Healthcare.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Healthcare.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240627131807_AddOneToManyScheduleEmployeeRelationship")]
    partial class AddOneToManyScheduleEmployeeRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Healthcare.Domain.Entities.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("DateOfAppointment")
                        .HasColumnType("date");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeOnly>("TimeOfAppointment")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("DATE")
                        .HasColumnName("HireDate");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Employees", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.MedicalDepartment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("MedicalDepartments", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Patient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("FRI")
                        .HasColumnType("bit");

                    b.Property<bool>("MON")
                        .HasColumnType("bit");

                    b.Property<bool>("SAT")
                        .HasColumnType("bit");

                    b.Property<bool>("SUN")
                        .HasColumnType("bit");

                    b.Property<bool>("THU")
                        .HasColumnType("bit");

                    b.Property<bool>("TUE")
                        .HasColumnType("bit");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.Property<bool>("WED")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schedules", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Accountant", b =>
                {
                    b.HasBaseType("Healthcare.Domain.Entities.Employee");

                    b.ToTable("Accountants");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Doctor", b =>
                {
                    b.HasBaseType("Healthcare.Domain.Entities.Employee");

                    b.Property<string>("MedicalDepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("MedicalDepartmentId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Nurse", b =>
                {
                    b.HasBaseType("Healthcare.Domain.Entities.Employee");

                    b.Property<string>("MedicalDepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("MedicalDepartmentId");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Pharmacist", b =>
                {
                    b.HasBaseType("Healthcare.Domain.Entities.Employee");

                    b.ToTable("Pharmacists");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Receptionist", b =>
                {
                    b.HasBaseType("Healthcare.Domain.Entities.Employee");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healthcare.Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Employees")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("Healthcare.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar")
                                .HasColumnName("Street");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Accountant", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("Healthcare.Domain.Entities.Accountant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("Healthcare.Domain.Entities.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healthcare.Domain.Entities.MedicalDepartment", "MedicalDepartment")
                        .WithMany("Doctors")
                        .HasForeignKey("MedicalDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalDepartment");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Nurse", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("Healthcare.Domain.Entities.Nurse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healthcare.Domain.Entities.MedicalDepartment", "MedicalDepartment")
                        .WithMany("Nurses")
                        .HasForeignKey("MedicalDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalDepartment");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Pharmacist", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("Healthcare.Domain.Entities.Pharmacist", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Receptionist", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("Healthcare.Domain.Entities.Receptionist", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.MedicalDepartment", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Nurses");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}

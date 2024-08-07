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
    [Migration("20240709134226_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Employees", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Lab", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Labs", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.LabResult", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppointmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabTestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("VARCHAR");

                    b.Property<DateOnly>("ResultDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("LabTestId");

                    b.ToTable("LabResults", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.LabTest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.ToTable("LabTests", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.MedicalDepartment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("MedicalDepartments", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Medication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<DateOnly>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Medications", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Patient", b =>
                {
                    b.Property<string>("Id")
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

            modelBuilder.Entity("Healthcare.Domain.Entities.Prescription", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppointmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("PrescriptionDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Prescriptions", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.PrescriptionMedication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("MedicationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrescriptionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("PrescriptionMedications", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AvailabilityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalDepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalDepartmentId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Schedule", b =>
                {
                    b.Property<string>("Id")
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.OwnsOne("Healthcare.Domain.ValueObjects.Address", "AddressInformation", b1 =>
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

                    b.OwnsOne("Healthcare.Domain.ValueObjects.PhoneNumber", "Phone", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar")
                                .HasColumnName("Phone");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("AddressInformation");

                    b.Navigation("Phone");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.LabResult", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Appointment", "Appointment")
                        .WithMany("LabResults")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healthcare.Domain.Entities.LabTest", "LabTest")
                        .WithMany("LabResults")
                        .HasForeignKey("LabTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("LabTest");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.LabTest", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Lab", "Lab")
                        .WithMany("LabTests")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Prescription", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.PrescriptionMedication", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.Medication", "Medication")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Healthcare.Domain.Entities.Prescription", "Prescription")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Room", b =>
                {
                    b.HasOne("Healthcare.Domain.Entities.MedicalDepartment", "MedicalDepartment")
                        .WithMany("Rooms")
                        .HasForeignKey("MedicalDepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MedicalDepartment");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Schedule", b =>
                {
                    b.OwnsOne("Healthcare.Domain.ValueObjects.TimeSlot", "TimeSlot", b1 =>
                        {
                            b1.Property<string>("ScheduleId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<TimeSpan>("EndTime")
                                .HasColumnType("time")
                                .HasColumnName("EndTime");

                            b1.Property<TimeSpan>("StartTime")
                                .HasColumnType("time")
                                .HasColumnName("StartTime");

                            b1.HasKey("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.WithOwner()
                                .HasForeignKey("ScheduleId");
                        });

                    b.Navigation("TimeSlot")
                        .IsRequired();
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
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Doctors_MedicalDepartments_MedicalDepartmentId");

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

            modelBuilder.Entity("Healthcare.Domain.Entities.Appointment", b =>
                {
                    b.Navigation("LabResults");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Lab", b =>
                {
                    b.Navigation("LabTests");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.LabTest", b =>
                {
                    b.Navigation("LabResults");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.MedicalDepartment", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Nurses");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Medication", b =>
                {
                    b.Navigation("PrescriptionMedications");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Healthcare.Domain.Entities.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedications");
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

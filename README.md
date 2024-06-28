# Healthcare
Database for an health care mental to provide services for our patients

``` sql
Create Database Healthcare;
Go
Use Healthcare;
```

##### Labs
``` sql
-- Labs Table
CREATE TABLE [Labs] (
    [Id] nvarchar(450) NOT NULL,
    [LabName] nvarchar(100) NOT NULL,
    [Location] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Labs] PRIMARY KEY ([Id])
);
GO
```

##### MedicalDepartments
``` sql
-- MedicalDepartments Table
CREATE TABLE [MedicalDepartments] (
    [Id] nvarchar(450) NOT NULL,
    [Name] varchar(40) NOT NULL,
    CONSTRAINT [PK_MedicalDepartments] PRIMARY KEY ([Id])
);
GO
```

##### Medications
``` sql
-- Medications Table
CREATE TABLE [Medications] (
    [Id] nvarchar(450) NOT NULL,
    [MedicationName] varchar(100) NOT NULL,
    [ExpireDate] date NOT NULL,
    [Description] varchar(255) NOT NULL,
    [Price] decimal(15,2) NOT NULL,
    CONSTRAINT [PK_Medications] PRIMARY KEY ([Id])
);
GO
```

##### Patients
``` sql
-- Patients Table
CREATE TABLE [Patients] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] varchar(50) NOT NULL,
    [LastName] varchar(50) NOT NULL,
    [Phone] varchar(20) NOT NULL,
    [Email] varchar(125) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([Id])
);
GO
```

##### Schedules
``` sql
-- Schedules Table
CREATE TABLE [Schedules] (
    [Id] nvarchar(450) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [StartTime] time NOT NULL,
    [EndTime] time NOT NULL,
    [SUN] bit NOT NULL,
    [MON] bit NOT NULL,
    [TUE] bit NOT NULL,
    [WED] bit NOT NULL,
    [THU] bit NOT NULL,
    [FRI] bit NOT NULL,
    [SAT] bit NOT NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY ([Id])
);
GO
```

##### Employees
``` sql
-- Employees
CREATE TABLE [Employees] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] varchar(50) NOT NULL,
    [LastName] varchar(50) NOT NULL,
    [Phone] varchar(20) NOT NULL,
    [JobTitle] varchar(50) NOT NULL,
    [Salary] decimal(18,2) NOT NULL,
    [DateOfBirth] DATE NOT NULL,
    [HireDate] DATE NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [Email] varchar(125) NOT NULL,
    [Street] varchar(50) NULL,
    [City] varchar(50) NULL,
    [State] varchar(20) NULL,
    [PostalCode] varchar(10) NULL,
    [Country] varchar(50) NULL,
    [ScheduleId] nvarchar(450) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Schedules_ScheduleId] FOREIGN KEY ([ScheduleId]) REFERENCES [Schedules] ([Id]) ON DELETE SET NULL
);
GO

CREATE TABLE [Accountants] (
    [Id] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Accountants] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Accountants_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Doctors] (
    [Id] nvarchar(450) NOT NULL,
    [MedicalDepartmentId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Doctors_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Doctors_MedicalDepartments_MedicalDepartmentId] FOREIGN KEY ([MedicalDepartmentId]) REFERENCES [MedicalDepartments] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Nurses] (
    [Id] nvarchar(450) NOT NULL,
    [MedicalDepartmentId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Nurses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Nurses_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Nurses_MedicalDepartments_MedicalDepartmentId] FOREIGN KEY ([MedicalDepartmentId]) REFERENCES [MedicalDepartments] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Pharmacists] (
    [Id] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Pharmacists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pharmacists_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Receptionists] (
    [Id] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Receptionists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Receptionists_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
);
GO

```

##### Appointments
``` sql
-- Appointments Table
CREATE TABLE [Appointments] (
    [Id] nvarchar(450) NOT NULL,
    [Reason] nvarchar(max) NULL,
    [DateOfAppointment] date NOT NULL,
    [TimeOfAppointment] time NOT NULL,
    [Paid] bit NOT NULL,
    [DoctorId] nvarchar(450) NOT NULL,
    [PatientId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Appointments_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Appointments_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
);
GO
```


##### LabResults
``` sql
-- LabResults Table
CREATE TABLE [LabResults] (
    [Id] nvarchar(450) NOT NULL,
    [LabTestId] nvarchar(450) NOT NULL,
    [AppointmentId] nvarchar(450) NOT NULL,
    [Result] VARCHAR(128) NOT NULL,
    [ResultDate] date NOT NULL,
    CONSTRAINT [PK_LabResults] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LabResults_Appointments_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LabResults_LabTests_LabTestId] FOREIGN KEY ([LabTestId]) REFERENCES [LabTests] ([Id]) ON DELETE CASCADE
);
GO
```

##### Prescriptions with Medicines
``` sql
CREATE TABLE [Prescriptions] (
    [Id] nvarchar(450) NOT NULL,
    [AppointmentId] nvarchar(450) NOT NULL,
    [PrescriptionDate] date NOT NULL,
    CONSTRAINT [PK_Prescriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Prescriptions_Appointments_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PrescriptionMedications] (
    [Id] nvarchar(450) NOT NULL,
    [PrescriptionId] nvarchar(450) NOT NULL,
    [MedicationId] nvarchar(450) NOT NULL,
    [Dosage] varchar(15) NOT NULL,
    [Instructions] varchar(255) NOT NULL,
    CONSTRAINT [PK_PrescriptionMedications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PrescriptionMedications_Medications_MedicationId] FOREIGN KEY ([MedicationId]) REFERENCES [Medications] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PrescriptionMedications_Prescriptions_PrescriptionId] FOREIGN KEY ([PrescriptionId]) REFERENCES [Prescriptions] ([Id]) ON DELETE CASCADE
);
GO
```

``` sql
-- indexs
CREATE INDEX [IX_Appointments_DoctorId] ON [Appointments] ([DoctorId]);
GO


CREATE INDEX [IX_Appointments_PatientId] ON [Appointments] ([PatientId]);
GO


CREATE INDEX [IX_Doctors_MedicalDepartmentId] ON [Doctors] ([MedicalDepartmentId]);
GO


CREATE INDEX [IX_Employees_ScheduleId] ON [Employees] ([ScheduleId]);
GO


CREATE INDEX [IX_LabResults_AppointmentId] ON [LabResults] ([AppointmentId]);
GO


CREATE INDEX [IX_LabResults_LabTestId] ON [LabResults] ([LabTestId]);
GO


CREATE INDEX [IX_LabTests_LabId] ON [LabTests] ([LabId]);
GO


CREATE INDEX [IX_Nurses_MedicalDepartmentId] ON [Nurses] ([MedicalDepartmentId]);
GO


CREATE INDEX [IX_PrescriptionMedications_MedicationId] ON [PrescriptionMedications] ([MedicationId]);
GO


CREATE INDEX [IX_PrescriptionMedications_PrescriptionId] ON [PrescriptionMedications] ([PrescriptionId]);
GO


CREATE INDEX [IX_Prescriptions_AppointmentId] ON [Prescriptions] ([AppointmentId]);
GO


CREATE INDEX [IX_Rooms_MedicalDepartmentId] ON [Rooms] ([MedicalDepartmentId]);
GO
```
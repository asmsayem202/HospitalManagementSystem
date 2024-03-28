using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Library.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.AppointmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    BloodTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.BloodTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    ReportTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefTypeID = table.Column<int>(type: "int", nullable: true),
                    RefTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.WardId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.UserId, x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodTypeID = table.Column<int>(type: "int", nullable: false),
                    InsuranceInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_BloodTypes_BloodTypeID",
                        column: x => x.BloodTypeID,
                        principalTable: "BloodTypes",
                        principalColumn: "BloodTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shift = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemId);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    NurseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.NurseId);
                    table.ForeignKey(
                        name: "FK_Nurses_Wards_WardID",
                        column: x => x.WardID,
                        principalTable: "Wards",
                        principalColumn: "WardId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Wards_WardID",
                        column: x => x.WardID,
                        principalTable: "Wards",
                        principalColumn: "WardId");
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OT_Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicineFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsultancyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BedCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OthersFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BalanceDue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_Billings_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportTypeID = table.Column<int>(type: "int", nullable: false),
                    ReportAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_ReportTypes_ReportTypeID",
                        column: x => x.ReportTypeID,
                        principalTable: "ReportTypes",
                        principalColumn: "ReportTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeID",
                        column: x => x.AppointmentTypeID,
                        principalTable: "AppointmentTypes",
                        principalColumn: "AppointmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emergencies",
                columns: table => new
                {
                    EmergencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmergencyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencies", x => x.EmergencyId);
                    table.ForeignKey(
                        name: "FK_Emergencies_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emergencies_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emergencies_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPrescribes",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FollowupNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPrescribes", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_AppointmentPrescribes_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentID = table.Column<int>(type: "int", nullable: true),
                    EmergencyID = table.Column<int>(type: "int", nullable: true),
                    WardID = table.Column<int>(type: "int", nullable: false),
                    NurseID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    AdmissionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.AdmissionId);
                    table.ForeignKey(
                        name: "FK_Admissions_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                    table.ForeignKey(
                        name: "FK_Admissions_Emergencies_EmergencyID",
                        column: x => x.EmergencyID,
                        principalTable: "Emergencies",
                        principalColumn: "EmergencyId");
                    table.ForeignKey(
                        name: "FK_Admissions_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Wards_WardID",
                        column: x => x.WardID,
                        principalTable: "Wards",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyPrescribes",
                columns: table => new
                {
                    EmergencyID = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FollowupNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyPrescribes", x => x.EmergencyID);
                    table.ForeignKey(
                        name: "FK_EmergencyPrescribes_Emergencies_EmergencyID",
                        column: x => x.EmergencyID,
                        principalTable: "Emergencies",
                        principalColumn: "EmergencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPrescribeDetails",
                columns: table => new
                {
                    AppointmentPrescribeDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID = table.Column<int>(type: "int", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosgae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPrescribeDetails", x => x.AppointmentPrescribeDetailsId);
                    table.ForeignKey(
                        name: "FK_AppointmentPrescribeDetails_AppointmentPrescribes_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "AppointmentPrescribes",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discharges",
                columns: table => new
                {
                    DischargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionID = table.Column<int>(type: "int", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DischargeInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharges", x => x.DischargeId);
                    table.ForeignKey(
                        name: "FK_Discharges_Admissions_AdmissionID",
                        column: x => x.AdmissionID,
                        principalTable: "Admissions",
                        principalColumn: "AdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyPrescribeDetails",
                columns: table => new
                {
                    EmergencyPrescribeDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyID = table.Column<int>(type: "int", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosgae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyPrescribeDetails", x => x.EmergencyPrescribeDetailsId);
                    table.ForeignKey(
                        name: "FK_EmergencyPrescribeDetails_EmergencyPrescribes_EmergencyID",
                        column: x => x.EmergencyID,
                        principalTable: "EmergencyPrescribes",
                        principalColumn: "EmergencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "General Consultation" },
                    { 2, "Specialist Consultation" },
                    { 3, "Follow-up Appointment" },
                    { 4, "Maternity Appointment" },
                    { 5, "Vaccination/Immunization" },
                    { 6, "Surgical Consultation" },
                    { 7, "Emergency Consultation" },
                    { 8, "Nutritional Counseling" },
                    { 9, "Lab Work or Blood Tests" }
                });

            migrationBuilder.InsertData(
                table: "BloodTypes",
                columns: new[] { "BloodTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "A+" },
                    { 2, "A-" },
                    { 3, "AB+" },
                    { 4, "AB-" },
                    { 5, "B+" },
                    { 6, "B-" },
                    { 7, "O+" },
                    { 8, "O-" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "Medicine" },
                    { 2, "ENT" },
                    { 3, "Child" },
                    { 4, "Gynecology" },
                    { 5, "BurnUnit" },
                    { 6, "Cardiology" },
                    { 7, "Orthopedic" },
                    { 8, "Surgical" },
                    { 9, "Neurology" },
                    { 10, "Dental" }
                });

            migrationBuilder.InsertData(
                table: "ReportTypes",
                columns: new[] { "ReportTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Discharge Summary" },
                    { 2, "Pathology Report" },
                    { 3, "Laboratory Report" },
                    { 4, "Consultation Report" },
                    { 5, "Anesthesia Report" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Address", "ContactNo", "Designation", "Email", "ImagePath", "Shift", "StaffName" },
                values: new object[,]
                {
                    { 1, "Dhaka", "01823459999", "Hospital Administrator", "karim@gmail.com", null, 0, "Md.Karim" },
                    { 2, "ctg", "01823459977", "Chief Medical Officer (CMO)", "rahim@gmail.com", null, 0, "Md.Rahim" },
                    { 3, "Dhaka", "01623459978", "Chief Nursing Officer (CNO)", "jannat@gmail.com", null, 0, "Mss.Jannat" },
                    { 4, "ctg", "01523459977", "Director of Operations", "maruf@gmail.com", null, 0, "Md.Maruf" },
                    { 5, "ctg", "01823456645", "Finance Manager", "krim45@gmail.com", null, 0, "Md.Krim" },
                    { 6, "Dhaka", "01823459977", "Human Resources Manager:", "hasib@gmail.com", null, 0, "Md.Hasib" },
                    { 7, "ctg", "01523459990", "Information Technology (IT) Manager:", "aziz90@gmail.com", null, 0, "Md.Aziz" },
                    { 8, "ctg", "01823459778", "Quality Improvement Manager", "rashed78@gmail.com", null, 0, "Md.Rashed" },
                    { 9, "Dhaka", "01823459989", "Medical Records Manager", "habib@gmail.com", null, 0, "Md.Habib" },
                    { 10, "ctg", "01823459999", "Supply Chain Manager", "adil@gmail.com", null, 0, "Md.Adil" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "ContactNo", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "ctg", "01823456612", "timelyproductltd.@gmail.com", "Timely Product Ltd." },
                    { 2, "ctg", "01823456622", " crifooIntertradeltd.@gmail.com", " Crifoo Intertrade Ltd." },
                    { 3, "ctg", "01523457712", " Care71@gmail.com", " 71 Care" },
                    { 4, "Dhaka", "01823456999", "continentalsurgicalhouse@gmail.com", "Continental Surgical House" },
                    { 5, "Dhaka", "01823459999", "anifcohealthcare@gmail.com", "Anifco Healthcare" },
                    { 6, "ctg", "01823456777", "bmabazar777@gmail.com", "BMA Bazar" }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "WardId", "Name" },
                values: new object[,]
                {
                    { 1, "Medicine ward " },
                    { 2, "ENT ward " },
                    { 3, "Child ward " },
                    { 4, "Gynecology Ward " },
                    { 5, "Burn Unit Ward" },
                    { 6, "Cardiology Ward" },
                    { 7, "Orthopedic Ward " },
                    { 8, "Surgical Ward " },
                    { 9, "Neurology Ward" },
                    { 10, "Dental Ward" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "ContactNo", "DepartmentID", "Email", "ImagePath", "Name", "Schedule", "Shift", "Specialization" },
                values: new object[,]
                {
                    { 1, "+880-181-2225587", 1, "farhana@example.com", null, "Dr. Farhana Rahman", "Sat-Thu 10-1", 0, "Gynecologist" },
                    { 2, "+880-171-1234567", 1, "mohammad.rahman@example.com", null, "Dr. Mohammad Rahman", "Sun-Thu 9-1", 1, "Cardiologist" },
                    { 3, "+880-191-9876543", 2, "fatima.ahmed@example.com", null, "Dr. Fatima Ahmed", "Sun-Thu 10-2", 2, "Dermatologist" },
                    { 4, "+880-181-8765432", 2, "ayesha.khan@example.com", null, "Dr. Ayesha Khan", "Sun-Thu 8-12", 0, "Neurologist" },
                    { 5, "+880-171-2345678", 3, "nazia.islam@example.com", null, "Dr. Nazia Islam", "Sat-Thu 9-1", 1, "Obstetrician" },
                    { 6, "+880-191-3456789", 3, "kamal.hossain@example.com", null, "Dr. Kamal Hossain", "Sat-Thu 10-2", 2, "Endocrinologist" },
                    { 7, "+880-181-4567890", 4, "sabrina.yasmin@example.com", null, "Dr. Sabrina Yasmin", "Sat-Thu 8-12", 0, "Ophthalmologist" },
                    { 8, "+880-171-5678901", 4, "rahman.chowdhury@example.com", null, "Dr. Rahman Chowdhury", "Sat-Thu 9-1", 1, "Orthodontist" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "InventoryItemId", "Category", "Name", "Price", "Quantity", "SupplierID" },
                values: new object[,]
                {
                    { 1, "latex", "Bandages", 100m, 50, 2 },
                    { 3, "Normal", "Gauze pads", 10000m, 500, 1 },
                    { 4, "10ml", "Syringes", 1000m, 50, 1 },
                    { 5, "40mm", "Needles", 100m, 50, 3 },
                    { 6, "Peripheral IV", "IV catheters", 100m, 50, 4 },
                    { 7, "Normal", "Surgical masks", 100m, 50, 2 },
                    { 8, "Antiseptics & Disinfectants", "Alcohol swabs", 100m, 50, 5 },
                    { 9, "Normal", "Bandages", 100m, 50, 6 },
                    { 10, "general", "Bandages", 10000m, 50, 6 }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "NurseId", "ContactNo", "ImagePath", "Name", "Shift", "WardID" },
                values: new object[,]
                {
                    { 1, "0123456789", null, "Lutfarnahar", 0, 1 },
                    { 2, "0123222789", null, "Nahar", 1, 1 },
                    { 3, "0123336789", null, "Ayesha", 2, 1 },
                    { 4, "0123456744", null, "Jamila", 0, 2 },
                    { 5, "0123456775", null, "Runa khatun", 1, 2 },
                    { 6, "0123456766", null, "Nasrin", 2, 2 },
                    { 7, "0123456663", null, "Arifa", 0, 7 },
                    { 8, "0123458879", null, "Maria ", 1, 8 },
                    { 9, "0123452299", null, "Sanjida", 2, 9 },
                    { 10, "0123412389", null, "Riya ", 0, 10 },
                    { 11, "0123789789", null, "Priya", 1, 1 },
                    { 12, "0123455669", null, "Puja Shill", 2, 2 },
                    { 13, "0188456789", null, "Ratna khatun", 0, 3 },
                    { 14, "01643456789", null, "Tuli ", 1, 4 },
                    { 15, "0198456789", null, "Tasnia", 2, 5 },
                    { 16, "0155456789", null, "Urmi", 0, 6 },
                    { 17, "0155456689", null, "Rahima", 1, 7 },
                    { 18, "0177756789", null, "Amena", 2, 8 },
                    { 19, "018976789", null, "Latifa Akter", 0, 9 },
                    { 20, "012655569", null, "Farin akter", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "Age", "BloodTypeID", "ContactNo", "Email", "Gender", "InsuranceInformation", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "123 ABC Street, Dhaka", 28, 1, "+880-171-1234567", "ayesha.rahman@example.com", 2, "Policy #123456", "Ayesha Rahman", "Active" },
                    { 2, "456 XYZ Road, Chittagong", 30, 2, "+880-191-2345678", "mohammad.ali@example.com", 1, "Policy #789012", "Mohammad Ali", "Active" },
                    { 3, "789 LMN Avenue, Sylhet", 32, 3, "+880-181-3456789", "fatima.khan@example.com", 2, "Policy #345678", "Fatima Khan", "Active" },
                    { 4, "321 PQR Lane, Rajshahi", 26, 1, "+880-171-4567890", "rahim.khan@example.com", 1, "Policy #234567", "Rahim Khan", "Active" },
                    { 5, "789 XYZ Street, Khulna", 33, 2, "+880-191-5678901", "nusrat.jahan@example.com", 2, "Policy #890123", "Nusrat Jahan", "Active" },
                    { 6, "147 LMN Road, Barishal", 29, 3, "+880-181-6789012", "kamal.hossain@example.com", 1, "Policy #456789", "Kamal Hossain", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomNumber", "Status", "WardID" },
                values: new object[,]
                {
                    { 1, "A-101", "Standard Room", 1 },
                    { 2, "B-102", "General Room ", 1 },
                    { 3, "C-103", "VIP Room ", 1 },
                    { 4, "A-104", " Standard Room", 2 },
                    { 5, "B-105", "General Room  ", 2 },
                    { 6, "C-106", " VIP Room", 2 },
                    { 7, "A-107", "Standard Room", 3 },
                    { 8, "B-108", " General Room ", 3 },
                    { 9, "C-109", "VIP Room", 3 },
                    { 10, "A-110", " Standard Room", 4 },
                    { 11, "B-111", "General Room ", 4 },
                    { 12, "C-112", " VIP Room", 4 },
                    { 13, "A-201", "Standard Room", 5 },
                    { 14, "B-202", " General Room", 5 },
                    { 15, "C-203", "VIP Room ", 5 },
                    { 16, "A-204", " Standard Room", 6 },
                    { 17, "B-205", "General Room", 6 },
                    { 18, "C-206", " VIP Room ", 6 },
                    { 19, "A-207", "Standard Room", 7 },
                    { 20, "B-208", " General Room", 7 },
                    { 21, "A-209", "Standard Room", 8 },
                    { 22, "B-210", " General Room", 8 },
                    { 23, "A-211", "Standard Room", 9 },
                    { 24, "B-212", " General Room", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AppointmentID",
                table: "Admissions",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_EmergencyID",
                table: "Admissions",
                column: "EmergencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_NurseID",
                table: "Admissions",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_RoomID",
                table: "Admissions",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_WardID",
                table: "Admissions",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPrescribeDetails_AppointmentID",
                table: "AppointmentPrescribeDetails",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeID",
                table: "Appointments",
                column: "AppointmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DepartmentID",
                table: "Appointments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PatientID",
                table: "Billings",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Discharges_AdmissionID",
                table: "Discharges",
                column: "AdmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_DepartmentID",
                table: "Emergencies",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_DoctorID",
                table: "Emergencies",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_PatientID",
                table: "Emergencies",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyPrescribeDetails_EmergencyID",
                table: "EmergencyPrescribeDetails",
                column: "EmergencyID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_SupplierID",
                table: "InventoryItems",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_WardID",
                table: "Nurses",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodTypeID",
                table: "Patients",
                column: "BloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PatientID",
                table: "Reports",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportTypeID",
                table: "Reports",
                column: "ReportTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardID",
                table: "Rooms",
                column: "WardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentPrescribeDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Discharges");

            migrationBuilder.DropTable(
                name: "EmergencyPrescribeDetails");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AppointmentPrescribes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "EmergencyPrescribes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Emergencies");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "BloodTypes");
        }
    }
}

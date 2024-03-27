using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Library.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Suppliers_SupplierID",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropColumn(
                name: "InventoryItemsID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "ReportTypes");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "BloodTypes");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "AppointmentTypes");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Suppliers_SupplierID",
                table: "InventoryItems",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Suppliers_SupplierID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemsID",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "ReportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "InventoryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "BloodTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "AppointmentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    NurseID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ShiftName = table.Column<int>(type: "int", nullable: false),
                    ShiftStatus = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Shifts_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseId");
                    table.ForeignKey(
                        name: "FK_Shifts_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffId");
                });

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 1,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 2,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 3,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 4,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 5,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 6,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 7,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 8,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 9,
                column: "AppointmentID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 1,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 2,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 3,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 4,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 5,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 6,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 7,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "BloodTypeId",
                keyValue: 8,
                column: "PatientID",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReportTypes",
                keyColumn: "ReportTypeId",
                keyValue: 1,
                column: "ReportID",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReportTypes",
                keyColumn: "ReportTypeId",
                keyValue: 2,
                column: "ReportID",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReportTypes",
                keyColumn: "ReportTypeId",
                keyValue: 3,
                column: "ReportID",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReportTypes",
                keyColumn: "ReportTypeId",
                keyValue: 4,
                column: "ReportID",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReportTypes",
                keyColumn: "ReportTypeId",
                keyValue: 5,
                column: "ReportID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_DoctorID",
                table: "Shifts",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_NurseID",
                table: "Shifts",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_StaffID",
                table: "Shifts",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Suppliers_SupplierID",
                table: "InventoryItems",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");
        }
    }
}

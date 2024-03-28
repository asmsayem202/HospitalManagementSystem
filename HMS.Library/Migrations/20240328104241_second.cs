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
                name: "FK_Wards_Patients_PatientId",
                table: "Wards");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Wards",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Wards_PatientId",
                table: "Wards",
                newName: "IX_Wards_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Patients_PatientID",
                table: "Wards",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Patients_PatientID",
                table: "Wards");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Wards",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Wards_PatientID",
                table: "Wards",
                newName: "IX_Wards_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Patients_PatientId",
                table: "Wards",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}

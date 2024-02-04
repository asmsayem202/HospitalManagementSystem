using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Library.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmergencyID",
                table: "Admissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_EmergencyID",
                table: "Admissions",
                column: "EmergencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Emergencies_EmergencyID",
                table: "Admissions",
                column: "EmergencyID",
                principalTable: "Emergencies",
                principalColumn: "EmergencyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Emergencies_EmergencyID",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_EmergencyID",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "EmergencyID",
                table: "Admissions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWebAssemblyR51.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class rrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Doctor_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Doctor_Code);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_Doctor_Code",
                        column: x => x.Doctor_Code,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Doctor_Code",
                table: "Patients",
                column: "Doctor_Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}

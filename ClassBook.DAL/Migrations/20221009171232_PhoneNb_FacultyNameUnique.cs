using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassBook.DAL.Migrations
{
    public partial class PhoneNb_FacultyNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FacultyName",
                table: "Faculties",
                column: "FacultyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassNumber",
                table: "Classes",
                column: "ClassNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_FacultyName",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassNumber",
                table: "Classes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProjectMVC.Migrations.UniversityDb
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherGroupId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherGroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

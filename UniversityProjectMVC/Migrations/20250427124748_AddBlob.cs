using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProjectMVC.Migrations.UniversityDb
{
    /// <inheritdoc />
    public partial class AddBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_TeacherGroups_TeacherGroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherGroups_TeacherGroupId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherGroups");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeacherGroupId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "TeacherGroupId",
                table: "Teachers",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_TeacherGroupId",
                table: "Teachers",
                newName: "IX_Teachers_GroupId");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupSubjectId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_GroupId",
                table: "Subjects",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_GroupId",
                table: "Subjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_GroupId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_GroupId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GroupSubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Teachers",
                newName: "TeacherGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                newName: "IX_Teachers_TeacherGroupId");

            migrationBuilder.CreateTable(
                name: "TeacherGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherGroupId",
                table: "Students",
                column: "TeacherGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TeacherGroups_TeacherGroupId",
                table: "Students",
                column: "TeacherGroupId",
                principalTable: "TeacherGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherGroups_TeacherGroupId",
                table: "Teachers",
                column: "TeacherGroupId",
                principalTable: "TeacherGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

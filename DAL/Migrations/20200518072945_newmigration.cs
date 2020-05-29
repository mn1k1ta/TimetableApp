using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherProfiles_Classes_ClassId",
                table: "TeacherProfiles");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "TimeTableOfTheDays",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "TeacherProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherProfiles_Classes_ClassId",
                table: "TeacherProfiles",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherProfiles_Classes_ClassId",
                table: "TeacherProfiles");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "TimeTableOfTheDays");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "TeacherProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherProfiles_Classes_ClassId",
                table: "TeacherProfiles",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTableOfTheDays_TimetableOfTheWeeks_TimeTableOfTheWeekId",
                table: "TimeTableOfTheDays");

            migrationBuilder.RenameColumn(
                name: "TimeTableOfTheWeekId",
                table: "TimeTableOfTheDays",
                newName: "TimetableOfTheWeekId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTableOfTheDays_TimeTableOfTheWeekId",
                table: "TimeTableOfTheDays",
                newName: "IX_TimeTableOfTheDays_TimetableOfTheWeekId");

            migrationBuilder.AlterColumn<int>(
                name: "TimetableOfTheWeekId",
                table: "TimeTableOfTheDays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "TimeTableOfTheDays",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLesson",
                table: "TimeTableOfTheDays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTableOfTheDays_TimetableOfTheWeeks_TimetableOfTheWeekId",
                table: "TimeTableOfTheDays",
                column: "TimetableOfTheWeekId",
                principalTable: "TimetableOfTheWeeks",
                principalColumn: "TimeTableOfTheWeekId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTableOfTheDays_TimetableOfTheWeeks_TimetableOfTheWeekId",
                table: "TimeTableOfTheDays");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TimeTableOfTheDays");

            migrationBuilder.DropColumn(
                name: "NumberOfLesson",
                table: "TimeTableOfTheDays");

            migrationBuilder.RenameColumn(
                name: "TimetableOfTheWeekId",
                table: "TimeTableOfTheDays",
                newName: "TimeTableOfTheWeekId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTableOfTheDays_TimetableOfTheWeekId",
                table: "TimeTableOfTheDays",
                newName: "IX_TimeTableOfTheDays_TimeTableOfTheWeekId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeTableOfTheWeekId",
                table: "TimeTableOfTheDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTableOfTheDays_TimetableOfTheWeeks_TimeTableOfTheWeekId",
                table: "TimeTableOfTheDays",
                column: "TimeTableOfTheWeekId",
                principalTable: "TimetableOfTheWeeks",
                principalColumn: "TimeTableOfTheWeekId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

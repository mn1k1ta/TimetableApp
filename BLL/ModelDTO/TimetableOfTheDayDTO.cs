using System;

namespace BLL.ModelDTO
{
    public class TimetableOfTheDayDTO
    {
        public int TimeTableOfTheDayId { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimetableOfTheWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public int NumberOfLesson { get; set; }
    }
}

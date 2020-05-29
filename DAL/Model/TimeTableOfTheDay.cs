using System;

namespace DAL.Model
{
    public class TimeTableOfTheDay
    {
       public int TimeTableOfTheDayId { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string ClassName { get; set; }
        public int TimetableOfTheWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public int NumberOfLesson { get; set; }
        public TimetableOfTheWeek TimetableOfTheWeek { get; set; }

    }
}

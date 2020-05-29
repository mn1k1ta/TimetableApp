using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public class TimetableOfTheWeek
    {
        public int TimeTableOfTheWeekId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Name { get; set; }
        public bool Actual { get; set; }
        public Class Class { get; set; }
        public ICollection<TimeTableOfTheDay> timeTableOfTheDays { get; set; }
        public TeacherProfile TeacherUserProfile { get; set; }
        public int TeacherUserProfileId { get; set; }

    }
}

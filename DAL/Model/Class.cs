using System.Collections.Generic;

namespace DAL.Model
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        TeacherProfile TeacherUserProfile { get; set; }
        public ICollection<TimetableOfTheWeek> timetableOfTheWeeks { get; set; }

    }
}

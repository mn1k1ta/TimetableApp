using System.Collections.Generic;

namespace DAL.Model
{
    public class TeacherProfile
    {
        public int TeacherProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool ActiveProfile { get; set; }
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public ICollection<TimetableOfTheWeek> timetableOfTheWeeks { get; set; }

    }
}

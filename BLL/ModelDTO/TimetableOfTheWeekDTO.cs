using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class TimetableOfTheWeekDTO
    {
        public int TimeTableOfTheWeekId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Name { get; set; }
        public bool Actual { get; set; }    
        public ICollection<TimetableOfTheDayDTO> timeTableOfTheDays { get; set; }        
        public int TeacherUserProfileId { get; set; }
    }
}

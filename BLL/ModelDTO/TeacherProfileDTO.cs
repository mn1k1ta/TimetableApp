using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class TeacherProfileDTO
    {
        public int TeacherProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool ActiveProfile { get; set; }
        public string TeacherId { get; set; }
   
        
    }
}


using Microsoft.AspNetCore.Identity;

namespace DAL.Model
{
    public class Teacher :IdentityUser
    {
        public TeacherProfile TeacherUserProfile { get; set; }
    }
}

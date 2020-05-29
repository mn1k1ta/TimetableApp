using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TeacherProfileRepository: BaseRepository<TeacherProfile>, ITeacherProfileRepository
    {
        public TeacherProfileRepository(DbContext context) : base(context)
        {

        }
    }
}

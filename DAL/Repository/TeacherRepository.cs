using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TeacherRepository :BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {

        }
    }
}

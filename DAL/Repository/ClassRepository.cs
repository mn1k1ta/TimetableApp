using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public  class ClassRepository : BaseRepository<Class>,IClassRepository
    {
        public ClassRepository(DbContext context) :base(context)
        {

        }
    }
}

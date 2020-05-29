using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TimetableOfTheWeekRepository : BaseRepository<TimetableOfTheWeek>, ITimeTableOfTheWeekRepository
    {
        public TimetableOfTheWeekRepository(DbContext context) : base(context)
        {

        }
    }
}

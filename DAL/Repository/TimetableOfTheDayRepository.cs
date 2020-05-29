using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TimetableOfTheDayRepository : BaseRepository<TimeTableOfTheDay> , ITimetableOfTheDayRepository
    {
        public TimetableOfTheDayRepository(DbContext context) : base(context)
        {

        }
    }
}

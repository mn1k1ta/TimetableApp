using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimetableOfTheDayService
    {
        Task<OperationDatails> CreateTimetableOfTheDayAsync(TimetableOfTheDayDTO timetableOfTheDayDTO, int teacherId, int timetableId);
        Task<OperationDatails> EditTimeTableOfTheDayAsync(TimetableOfTheDayDTO timetableOfTheDayDTO, int teacherId, int timetableId);
        Task<OperationDatails> DeleteTimetableOfTheDayAsync(int timetableOfTheDayId, int teacherId, int timetableId);
        Task<ICollection<TimetableOfTheDayDTO>> GetTimetableOfTheDayForWeekAsync(int timetableOfTheWeekId);
    }
}

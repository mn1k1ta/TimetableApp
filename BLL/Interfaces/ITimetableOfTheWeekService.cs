using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimetableOfTheWeekService
    {
        Task<OperationDatails> CreateTimatableOfTheWeekAsync(TimetableOfTheWeekDTO timetableOfTheWeekDTO, int teacherId);
        Task<OperationDatails> EditTimetableOfTheWeekAsync(TimetableOfTheWeekDTO timetableOfTheWeekDTO, int teacherId);
        Task<OperationDatails> DeleteTimetableAsync(int timetableId);
        Task<ICollection<TimetableOfTheWeekDTO>> GetAllTimetablesOfTheWeekAsync();
        Task<TimetableOfTheWeekDTO> GetTimetableOfTheWeekByIdAsync(int timetableId);
    }
}

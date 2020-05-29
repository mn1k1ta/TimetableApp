using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TimetableOfTheWeekService : ITimetableOfTheWeekService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public TimetableOfTheWeekService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDatails> CreateTimatableOfTheWeekAsync(TimetableOfTheWeekDTO timetableOfTheWeekDTO, int teacherId)
        {
            if (timetableOfTheWeekDTO == null)
                throw new ServiceException("Model is null!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not founnd", false);
            if (teacherProfile.ActiveProfile == false)
                throw new ServiceException("User with this id is not actived!", false);
            if (teacherProfile.ClassId == 0)
                throw new ServiceException("User with this id havent got a class", false);
            timetableOfTheWeekDTO.TeacherUserProfileId = teacherProfile.TeacherProfileId;
            timetableOfTheWeekDTO.Actual = false;
            _database.timeTableOfTheWeekRepository.Create(_mapper.Map<TimetableOfTheWeek>(timetableOfTheWeekDTO));
            await _database.SaveAsync();
            return new OperationDatails("Timetable of the week are created!", true);
        }

        public async Task<OperationDatails> EditTimetableOfTheWeekAsync(TimetableOfTheWeekDTO timetableOfTheWeekDTO, int teacherId)
        {
            if (timetableOfTheWeekDTO == null)
                throw new ServiceException("Timetable is null!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not founnd", false);
            if (teacherProfile.ActiveProfile == false)
                throw new ServiceException("User with this id is not actived!", false);
            if (teacherProfile.timetableOfTheWeeks == null)
                throw new ServiceException("User with this id already has timetable", false);
            var timetableOfTheWeek = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableOfTheWeekDTO.TimeTableOfTheWeekId);
            if (timetableOfTheWeek == null)
                throw new ServiceException("Timetable with this id is not found", false);
            _database.timeTableOfTheWeekRepository.Update(_mapper.Map(timetableOfTheWeekDTO,timetableOfTheWeek));
            await _database.SaveAsync();
            return new OperationDatails("Timetable is updated!", true);
        }

        public async Task<OperationDatails> DeleteTimetableAsync(int timetableId)
        {
            var timetableProfile = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableId);
            if (timetableProfile == null)
                throw new ServiceException("Timetable with this id is not found!", false);
            _database.timeTableOfTheWeekRepository.Delete(timetableProfile);
            await _database.SaveAsync();
            return new OperationDatails("Timetable is deleted!", true);
        }

        public async Task<ICollection<TimetableOfTheWeekDTO>> GetAllTimetablesOfTheWeekAsync()
        {
            var timetables = await _database.timeTableOfTheWeekRepository.GetAllAsync();
            return _mapper.Map<ICollection<TimetableOfTheWeekDTO>>(timetables);
        }

        public async Task<TimetableOfTheWeekDTO> GetTimetableOfTheWeekByIdAsync(int timetableId)
        {
            var timetable = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableId);
            if (timetable == null)
                throw new ServiceException("Timetable with this id is not found!", false);
            return _mapper.Map<TimetableOfTheWeekDTO>(timetable);
        }
    }
}

using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TimetableOfTheDayService : ITimetableOfTheDayService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public TimetableOfTheDayService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDatails> CreateTimetableOfTheDayAsync(TimetableOfTheDayDTO timetableOfTheDayDTO , int teacherId,int timetableId)
        {
            if (timetableOfTheDayDTO == null)
                throw new ServiceException("Timetable is null!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not founnd", false);
            if (teacherProfile.ActiveProfile == false)
                return new OperationDatails("User with this id is not actived!", false);
            if (teacherProfile.ClassId == 0)
                return new OperationDatails("User with this id havent got a class", false);
            if (teacherProfile.timetableOfTheWeeks == null)
                return new OperationDatails("User with this id havent got a timetable", false);
            var timetable = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableId);
            if (timetable == null)
                throw new ServiceException("Timetable with this id is null",false);
            var timetableOfTheDay = await _database.timetableOfTheDayRepository.GetWhereAsync(t => t.NumberOfLesson == timetableOfTheDayDTO.NumberOfLesson && t.DayOfWeek == timetableOfTheDayDTO.DayOfWeek);
            if (timetableOfTheDay.Count!=0)
                return new OperationDatails("Such lesson already is exists", false);
            if(timetable.TeacherUserProfileId!=teacherId)
                return new OperationDatails("This timetable mored not your", false);
            timetableOfTheDayDTO.TeacherName = teacherProfile.FirstName + " " + teacherProfile.LastName;
            timetableOfTheDayDTO.TimetableOfTheWeekId = timetableId;
            _database.timetableOfTheDayRepository.Create(_mapper.Map<TimeTableOfTheDay>(timetableOfTheDayDTO));
            await _database.SaveAsync();
            return new OperationDatails("Timetable is created!", true);
        }

        public async Task<OperationDatails> EditTimeTableOfTheDayAsync(TimetableOfTheDayDTO timetableOfTheDayDTO, int teacherId, int timetableId)
        {
            if (timetableOfTheDayDTO == null)
                throw new ServiceException("Timetable is null!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not founnd", false);
            if (teacherProfile.ActiveProfile == false)
                return new OperationDatails("User with this id is not actived!", false);
            if (teacherProfile.ClassId == 0)
                return new OperationDatails("User with this id havent got a class", false);
            if (teacherProfile.timetableOfTheWeeks == null)
                return new OperationDatails("User with this id havent got a timetable", false);
            var timetable = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableId);
            if (timetable == null)
                throw new ServiceException("Timetable with this id is null", false);
            if (timetable.TeacherUserProfileId != teacherId)
                return new OperationDatails("This timetable mored not your", false);
            var timetableOfTheDay = await _database.timetableOfTheDayRepository.GetByIdAsync(timetableOfTheDayDTO.TimeTableOfTheDayId);
            if (timetableOfTheDay == null)
                throw new ServiceException("Timetable with this id is not found", false);
            _database.timetableOfTheDayRepository.Create(_mapper.Map(timetableOfTheDayDTO, timetableOfTheDay));
            await _database.SaveAsync();
            return new OperationDatails("Updated!", true);
        }
        
        public async Task<OperationDatails> DeleteTimetableOfTheDayAsync(int timetableOfTheDayId, int teacherId, int timetableId)
        {         
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not founnd", false);
            if (teacherProfile.ActiveProfile == false)
                return new OperationDatails("User with this id is not actived!", false);
            if (teacherProfile.ClassId == 0)
                return new OperationDatails("User with this id havent got a class", false);
            if (teacherProfile.timetableOfTheWeeks == null)
                return new OperationDatails("User with this id havent got a timetable", false);
            var timetable = await _database.timeTableOfTheWeekRepository.GetByIdAsync(timetableId);
            if (timetable == null)
                throw new ServiceException("Timetable with this id is null", false);
            if (timetable.TeacherUserProfileId != teacherId)
                return new OperationDatails("This timetable mored not your", false);
            var timetableOfTheDay = await _database.timetableOfTheDayRepository.GetByIdAsync(timetableOfTheDayId);
            if (timetableOfTheDay == null)
                throw new ServiceException("Timetable with this id is not found", false);
            _database.timetableOfTheDayRepository.Delete(timetableOfTheDay);
            await _database.SaveAsync();
            return new OperationDatails("Deleted!", true);
        }

        public async Task<ICollection<TimetableOfTheDayDTO>> GetTimetableOfTheDayForWeekAsync(int timetableOfTheWeekId)
        {
            var timetables = await _database.timetableOfTheDayRepository.GetWhereAsync(t => t.TimetableOfTheWeekId == timetableOfTheWeekId);
            return _mapper.Map<ICollection<TimetableOfTheDayDTO>>(timetables);
        }
    }
}

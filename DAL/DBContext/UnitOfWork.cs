using DAL.Interfaces;
using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class UnitOfWork : IDisposable , IUnitOfWork
    {
        private  IClassRepository _classRepository;
        private  ITeacherProfileRepository _teacherProfileRepository;
        private  ITimetableOfTheDayRepository _timetableOfTheDayRepository;
        private  ITimeTableOfTheWeekRepository _timeTableOfTheWeekRepository;
        private  TimeTableContext _dBContext;
        public  SignInManager<Teacher> _signInManager { get; }
        public Teacher teacher { get; }

        public UnitOfWork(TimeTableContext _dBContext,
            Teacher teacher,
            SignInManager<Teacher> signInManager)
        {
            this._dBContext = _dBContext;
            this.teacher = teacher;
            this._signInManager = _signInManager;
        }

        public IClassRepository classRepository
        {
            get
            {
                if (_classRepository == null)
                    _classRepository = new ClassRepository(_dBContext);
                return _classRepository;
            }
        }

        public ITeacherProfileRepository teacherProfileRepository
        {
            get
            {
                if (_teacherProfileRepository == null)
                    _teacherProfileRepository = new TeacherProfileRepository(_dBContext);
                return _teacherProfileRepository;
            }
        }

        public ITimetableOfTheDayRepository timetableOfTheDayRepository
        {
            get
            {
                if (_timetableOfTheDayRepository == null)
                    _timetableOfTheDayRepository = new TimetableOfTheDayRepository(_dBContext);
                return _timetableOfTheDayRepository;
            }
        }

        public ITimeTableOfTheWeekRepository timeTableOfTheWeekRepository
        {
            get
            {
                if (_timeTableOfTheWeekRepository == null)
                    _timeTableOfTheWeekRepository = new TimetableOfTheWeekRepository(_dBContext);
                return _timeTableOfTheWeekRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dBContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dBContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}

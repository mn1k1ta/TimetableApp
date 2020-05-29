using DAL.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        SignInManager<Teacher> _signInManager { get; }
        Teacher teacher { get; }
        IClassRepository classRepository { get; }
        ITeacherProfileRepository teacherProfileRepository { get; }
        ITimetableOfTheDayRepository timetableOfTheDayRepository { get; }
        ITimeTableOfTheWeekRepository timeTableOfTheWeekRepository { get; }
        Task SaveAsync();

    }
}

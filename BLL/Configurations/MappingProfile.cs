using AutoMapper;
using BLL.ModelDTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TeacherProfile, TeacherProfileDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<TimeTableOfTheDay, TimetableOfTheDayDTO>().ReverseMap();
            CreateMap<TimetableOfTheWeek, TimetableOfTheWeekDTO>().ReverseMap();

        }
    }
}

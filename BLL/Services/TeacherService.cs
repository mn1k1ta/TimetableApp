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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDatails> CreateTeacherProfileAsync(TeacherProfileDTO teacherProfileDTO)
        {
            if (teacherProfileDTO == null)
               throw new ServiceException("TeacherProfile is NULL!", false);
            teacherProfileDTO.ActiveProfile = false;
            _database.teacherProfileRepository.Create(_mapper.Map<TeacherProfile>(teacherProfileDTO));
            await _database.SaveAsync();
            return new OperationDatails("TeacherProfile is Create", true);

        }

        public async Task<ICollection<TeacherProfileDTO>> GetTeacherProfileAsync()
        {
            var teacherProfile = await _database.teacherProfileRepository.GetWhereAsync(u=>u.ActiveProfile==true);
            return _mapper.Map<ICollection<TeacherProfileDTO>>(teacherProfile); 
        }

        public async Task<OperationDatails> EditTeacherProfileAsync(TeacherProfileDTO teacherProfileDTO)
        {
            if (teacherProfileDTO == null)
                throw new ServiceException("teacherUserProfile is null", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileDTO.TeacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("Teacher with this Id is not found!", false);
            if (teacherProfile.ActiveProfile == false)
                return new OperationDatails("not activated", false);
            _database.teacherProfileRepository.Update(_mapper.Map(teacherProfileDTO, teacherProfile));
            await _database.SaveAsync();
            return new OperationDatails("User data is updated!", true);
        }

        public async Task<OperationDatails> DeleteTeacherProfileAsync(int teacherProfileId)
        {
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("Teacher Profile is not found!", false);
            _database.teacherProfileRepository.Delete(teacherProfile);
            await _database.SaveAsync();
            return new OperationDatails("User is Deleted!", true);
        }

        public async Task<TeacherProfileDTO> GetTeacherProfileByIdAsync(int teacherProfileId)
        {
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("User with this id is not found!", false);
            return _mapper.Map<TeacherProfileDTO>(teacherProfile);
        }

        public async Task<OperationDatails> ActivateProfileAsync(int teacherProfileId)
        {
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("Profile is not found!", false);
            teacherProfile.ActiveProfile = true;
            _database.teacherProfileRepository.Update(teacherProfile);
            await _database.SaveAsync();
            return new OperationDatails("UserProfile is activated!", true);
        }

        public async Task<ICollection<TeacherProfileDTO>> GetNotActivedUsersProfileAsync()
        {
            var usersProfile = await _database.teacherProfileRepository.GetWhereAsync(u => u.ActiveProfile == false);
            return _mapper.Map<ICollection<TeacherProfileDTO>>(usersProfile);
        }
    }
}

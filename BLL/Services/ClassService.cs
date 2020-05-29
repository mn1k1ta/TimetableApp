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
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDatails> CreateClassAsync(ClassDTO classDTO , int teacherProfileId)
        {
            if (classDTO == null)
                throw new ServiceException("TeacherProfile is not found!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("User with this Id is not found", false);
            if (teacherProfile.ActiveProfile == false)
                throw new ServiceException("User with this id is not actived", false);
            if (teacherProfile.ClassId != 0)
                throw new ServiceException("The user with this id already has a class.", false);
            var classProfile = await _database.classRepository.GetWhereAsync(u => u.Name == classDTO.Name);
            if (classProfile.Count != 0)
                throw new ServiceException("Class with this name already exists!", false);
            _database.classRepository.Create(_mapper.Map<Class>(classDTO));
            teacherProfile.ClassId = teacherProfileId;
            _database.teacherProfileRepository.Update(teacherProfile);
            await _database.SaveAsync();
            return new OperationDatails("Class is are created", true);
        }

        public async Task<OperationDatails> EditClassAsync(ClassDTO classDTO , int teacherProfileId)
        {
            if (classDTO == null)
                throw new ServiceException("TeacherProfile is not found!", false);
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("User with this Id is not found", false);
            if (teacherProfile.ActiveProfile == false)
                throw new ServiceException("User with this id is not actived", false);            
            var classProfile = await _database.classRepository.GetByIdAsync(classDTO.ClassId);
            if (classProfile == null)
                throw new ServiceException("Class with this Id is not found!", false);
            if (teacherProfile.ClassId == classDTO.ClassId)
                throw new ServiceException("User with this id is not admin for this class", false);
            _database.classRepository.Update(_mapper.Map(classDTO, classProfile));
            await _database.SaveAsync();
            return new OperationDatails("Class is are updated!", true);
        } 

        public async Task<OperationDatails> DeleteClassAsync(int classId)
        {
            var classProfile = await _database.classRepository.GetByIdAsync(classId);
            if (classProfile == null)
                throw new ServiceException("Class with this id is not found!", false);
            _database.classRepository.Delete(classProfile);
            await _database.SaveAsync();
            return new OperationDatails("Class is are deleted!", true);
        }

        public async Task<ClassDTO> GetClassByUserAsync(int teacherProfileId)
        {
            var teacherProfile = await _database.teacherProfileRepository.GetByIdAsync(teacherProfileId);
            if (teacherProfile == null)
                throw new ServiceException("User with this Id is not found", false);
            var classProfile = await _database.classRepository.GetByIdAsync(teacherProfile.ClassId);
            if (classProfile == null)
                throw new ServiceException("This user is haven't got a class", false);
            return _mapper.Map<ClassDTO>(classProfile);
        }

        public async Task<ICollection<ClassDTO>> GetAllClassesAsync()
        {
            var classes = await _database.classRepository.GetAllAsync();
            return _mapper.Map<ICollection<ClassDTO>>(classes);
        }

        public async Task<ICollection<ClassDTO>> GetAllClassesByNameAsync(string className)
        {
            var classes = await _database.classRepository.GetWhereAsync(u => u.Name.Contains(className));
            return _mapper.Map<ICollection<ClassDTO>>(classes);
        }
    }
}

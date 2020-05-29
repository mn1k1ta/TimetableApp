using BLL.Helpers;
using BLL.ModelDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<OperationDatails> CreateTeacherProfileAsync(TeacherProfileDTO teacherProfileDTO);
        Task<ICollection<TeacherProfileDTO>> GetTeacherProfileAsync();
        Task<OperationDatails> EditTeacherProfileAsync(TeacherProfileDTO teacherProfileDTO);
        Task<OperationDatails> DeleteTeacherProfileAsync(int teacherProfileId);
        Task<TeacherProfileDTO> GetTeacherProfileByIdAsync(int teacherProfileId);
        Task<OperationDatails> ActivateProfileAsync(int teacherProfileId);
        Task<ICollection<TeacherProfileDTO>> GetNotActivedUsersProfileAsync();
    }
}

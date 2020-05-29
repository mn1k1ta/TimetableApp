using BLL.Helpers;
using BLL.ModelDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClassService
    {
        Task<OperationDatails> CreateClassAsync(ClassDTO classDTO, int teacherProfileId);
        Task<OperationDatails> EditClassAsync(ClassDTO classDTO, int teacherProfileId);
        Task<OperationDatails> DeleteClassAsync(int classId);
        Task<ClassDTO> GetClassByUserAsync(int teacherProfileId);
        Task<ICollection<ClassDTO>> GetAllClassesAsync();
        Task<ICollection<ClassDTO>> GetAllClassesByNameAsync(string className);
    }
}

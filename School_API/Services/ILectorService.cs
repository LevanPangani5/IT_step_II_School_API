using School_API.Data.Model.DTO;
using School_API.Data.Model;

namespace School_API.Services
{
    public interface ILectorService
    {
        Task<ICollection<Lector>?> GetAll();
        Task<Lector?> GetById(int Id);
        Task<bool> CreateLector(LectorCreateDto model);
        Task<bool> UpdateLector(int Id, LectorCreateDto model);
        Task<bool> DeleteLector(int Id);
        Task<float?> GetMaxGrade(int lectorId);
        Task<float?> GetMinGrade(int lectorId);
        Task<float?> GetAvgGrade(int lectorId);
        Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId);
        Task<List<(string LectorName, string StudentName)>?> GetLectorStudentNames(int lectorId);
    }
}

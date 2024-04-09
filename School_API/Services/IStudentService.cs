using School_API.Data.Model.DTO;
using School_API.Data.Model;

namespace School_API.Services
{
    public interface IStudentService
    {
        Task<ICollection<Student>?> GetAll();
        Task<Student?> GetById(int id);
        Task<bool> CreateStudent(StudentCreateDto model);
        Task<bool> UpdateStudent(int id, StudentCreateDto model);
        Task<bool> DeleteStudent(int id);
    }
}

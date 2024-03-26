using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_API.Data.Model.DTO;
using School_API.Data.Model;
using School_API.Services;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ICollection<Student>?> GetAll()
        {
            return await _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Student?> GetById(int id)
        {
            return await _studentService.GetById(id);
        }


        [HttpPost]
        public async Task<bool> CreateStudnent(StudentCreateDto model)
        {
            return await _studentService.CreateStudent(model);
        }

        [HttpPut]
        public async Task<bool> UpdateStudnent(int id, StudentCreateDto model)
        {
            return await _studentService.UpdateStudent(id, model);
        }


        [HttpDelete]
        public async Task<bool> DeleteStudnent(int Id)
        {
            return await _studentService.DeleteStudnent(Id);
        }
    }
}

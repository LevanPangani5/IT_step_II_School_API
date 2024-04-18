using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_API.Data.Model;
using School_API.Data.Model.DTO;
using School_API.Services;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        private readonly ILectorService _lectorService;

        public LectorController(ILectorService lectorService)
        {
            _lectorService = lectorService;
        }


        [HttpGet]
        public async Task<ICollection<Lector>?> GetAll()
        {
            return await _lectorService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Lector?> GetById(int id)
        {
            return await _lectorService.GetById(id);
        }


        [HttpPost]
        public async Task<bool> CreateLector(LectorCreateDto model)
        {
            return await _lectorService.CreateLector(model);
        }

        [HttpPut]
        public async Task<bool> UpdateLector(int id, LectorCreateDto model)
        {
            return await _lectorService.UpdateLector(id,model);
        }


        [HttpDelete]
        public async Task<bool> DeleteLector(int Id)
        {
            return await _lectorService.DeleteLector(Id);
        }


        [HttpGet]
        public async Task<float?> GetMaxGrade(int lectorId)
        {
            return await _lectorService.GetMaxGrade(lectorId);
        }

        [HttpGet]
        public async Task<float?> GetMinGrade(int lectorId)
        {
            return await _lectorService.GetMinGrade(lectorId);
        }

        [HttpGet]
        public async Task<float?> GetAvgGrade(int lectorId)
        {
            return await _lectorService.GetAvgGrade(lectorId);
        }

        [HttpGet]
        public async Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId)
        {
            return await _lectorService.GroupAndCountStudentsByNameForLector(lectorId);
        }
        [HttpGet]
        public async Task<List<(string LectorName, string StudentName)>?> GetLectorStudentNames(int lectorId)
        {
            return await _lectorService.GetLectorStudentNames(lectorId);
        }
    }
}

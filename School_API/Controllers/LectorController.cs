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
        private readonly LectorService _lectorService;

        public LectorController(LectorService lectorService)
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
    }
}

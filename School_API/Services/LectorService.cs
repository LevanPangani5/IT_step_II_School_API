using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Data.Model;
using School_API.Data.Model.DTO;

namespace School_API.Services
{
    public class LectorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LectorService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ICollection<Lector>?> GetAll()
        {
            try
            {
                var lectors = await _db.Lectors.ToListAsync();

                return lectors;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Lector?> GetById(int Id)
        {
            try
            {
                var lector= await _db.Lectors.FirstOrDefaultAsync(lector=>lector.Id==Id);
                return lector;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateLector(LectorCreateDto model)
        {
            var lector= _mapper.Map<Lector>(model);

            try
            {
                await _db.AddAsync(lector);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateLector(int Id, LectorCreateDto model)
        {
                var lector = await GetById(Id);
            try
            {
                if(lector == null)
                {
                    throw new Exception("Lector with such id does not exist");
                }
                _mapper.Map(model, lector);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteLector(int Id)
        {
            try
            {
                var lector=await _db.Lectors.FirstAsync(lector=>lector.Id== Id);
                if(lector != null)
                {
                    _db.Lectors.Remove(lector);
                    await _db.SaveChangesAsync();
                }
               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Data.Model;
using School_API.Data.Model.DTO;

namespace School_API.Services
{
    public class LectorService: ILectorService
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LectorService(IApplicationDbContext db, IMapper mapper)
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
                var lector = await _db.Lectors.FirstOrDefaultAsync(lector => lector.Id == Id);
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
                await _db.Lectors.AddAsync(lector);
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
                if (lector == null)
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
                var lector = await _db.Lectors.FirstAsync(lector => lector.Id == Id);
                if (lector != null)
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

        public async Task<float?> GetMaxGrade(int lectorId)
        {
            try
            {
                var lector= await _db.Lectors.Include(l=>l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Max(s=>s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<float?> GetMinGrade(int lectorId)
        {
            try
            {
                var lector = await _db.Lectors.Include(l => l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Min(s => s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<float?> GetAvgGrade(int lectorId)
        {
            try
            {
                var lector = await _db.Lectors.Include(l => l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Average(s => s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId)
        {
            try
            {
                var StudentsGroupedByName = await _db.Lectors
                    .Where(l => l.Id == lectorId)
                    .SelectMany(l => l.Students)
                    .GroupBy(s => s.Name)
                    .Select(g => new { Name = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Name, x => x.Count);
                return StudentsGroupedByName;
            }catch(Exception){
                return null;
            }
        }

        public async Task<List<(string LectorName, string StudentName)>?> GetLectorStudentNames(int lectorId)
        {
            try
            {
                var lectroStudnetNames = await (
                    from l in _db.Lectors
                    join s in _db.Students on l.Id equals s.Lector.Id
                    where l.Id == lectorId
                    select new { LectorName = l.Name, StudentName = s.Name })
                    .ToListAsync();

                return lectroStudnetNames.Select(l => (l.LectorName, l.StudentName)).ToList();

                /*
                   var lectroStudnetNames = await _db.Lectors
                     .Join(_db.Students, lector => lector.Id, student => student.Lector.Id,
                     (Lector, student) => new{
                         LectorName = Lector.Name,
                         getLectorStudentNames = student.Name,
                     }
                     ).ToListAsync();
                */
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_API.Data;
using School_API.Data.Model;
using School_API.Data.Model.DTO;
using System.Runtime.CompilerServices;

namespace School_API.Services
{
    public class StudentService
    {
        readonly private ApplicationDbContext _db;
        readonly private IMapper _mapper;

        public StudentService(ApplicationDbContext db, IMapper mapper )
        {
            _db = db;
            _mapper = mapper;
        }

       public async Task<ICollection<Student>?> GetAll()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Student?> GetById(int id)
        {
            try
            {
                return await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

       public  async Task<bool> CreateStudent(StudentCreateDto model)
        {
            try
            {
                var student = _mapper.Map<Student>(model);
                await _db.Students.AddAsync(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudent(int id, StudentCreateDto model)
        {
            try
            {
                var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student==null)
                {
                    throw new Exception("Student with this id does not exist");
                }
                _mapper.Map(model, student);

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudnent(int id)
        {
            try
            {
                var student = await _db.Students.FirstOrDefaultAsync(x=>x.Id==id);
                if(student == null)
                    throw new Exception("Student with this id does not exist");

                 _db.Students.Remove(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

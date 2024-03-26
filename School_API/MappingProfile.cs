using AutoMapper;
using School_API.Data.Model;
using School_API.Data.Model.DTO;

namespace School_API
{   //From DTO to Original and from original to DTO
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Lector, LectorCreateDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
        }
    }
}

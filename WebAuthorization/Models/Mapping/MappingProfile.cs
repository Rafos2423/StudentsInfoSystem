using AutoMapper;
using Microsoft.Build.Framework;
using WebAuthorization.Data.Identity;

namespace WebAuthorization.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Student, StudentModel>()
                .ForMember(dst => dst.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dst => dst.FullName,
                opt => opt.MapFrom(src => src.Name + " " + src.Id));

            this.CreateMap<StudentModel, Student>();
        }
    }
}

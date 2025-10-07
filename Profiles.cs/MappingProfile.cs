using AutoMapper;
using BackendMidterm.Models;
using BackendMidterm.Dtos;

namespace BackendMidterm.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map Class -> ClassDto
        CreateMap<Class, ClassDto>();

        // Map Student -> StudentDto
        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.ClassName,
                       opt => opt.MapFrom(src => src.Class.Name));

        // Map CreateStudentDto -> Student
        CreateMap<CreateStudentDto, Student>();
    }
}

using AutoMapper;
using thibackend.Models;
using thibackend.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping cho Class
        CreateMap<Class, ClassDto>();
        CreateMap<ClassDto, Class>();

        // Mapping cho Student
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}

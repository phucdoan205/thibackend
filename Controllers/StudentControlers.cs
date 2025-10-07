using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using thibackend.Models;
using thibackend.DTOs;

namespace thibackend.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            var result = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(result);
        }

        // POST api/students
        [HttpPost]
        public ActionResult<StudentDto> CreateStudent([FromBody] StudentDto studentDto)
        {
            var newStudent = _mapper.Map<Student>(studentDto);
            newStudent.Id = students.Count + 1;
            newStudent.ClassName = "CNTT1"; // gán tạm lớp mặc định

            students.Add(newStudent);

            var result = _mapper.Map<StudentDto>(newStudent);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, result);
        }
    }
}

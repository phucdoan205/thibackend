using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using thibackend.Models;
using thibackend.DTOs;

namespace thibackend.Controllers
{
    [ApiController]
    [Route("api/classes")]

    public class ClassController : ControllerBase
    {
        private static List<Class> classes = new List<Class>();
        private readonly IMapper _mapper;

        public ClassController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/class
        [HttpGet]
        public ActionResult<IEnumerable<ClassDto>> GetClasses()
        {
            var result = _mapper.Map<IEnumerable<ClassDto>>(classes);
            return Ok(result);
        }

        // POST api/class
        [HttpPost]
        public ActionResult<ClassDto> CreateClass([FromBody] ClassDto classDto)
        {
            var newClass = _mapper.Map<Class>(classDto);
            newClass.Id = classes.Count + 1;
            classes.Add(newClass);

            var result = _mapper.Map<ClassDto>(newClass);
            return CreatedAtAction(nameof(GetClasses), new { id = newClass.Id }, result);
        }
    }
}

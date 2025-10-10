using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnApiNetCore.Entity; 
using LearnApiNetCore.Models; 

namespace LearnApiNetCore.Controllers
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    // Lấy danh sách tất cả sinh viên (kèm tên lớp)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
    {
        // Include để lấy dữ liệu lớp học liên quan
        var students = await _context.Students
            .Include(s => s.Class)
            .ToListAsync();

        var result = _mapper.Map<IEnumerable<StudentDto>>(students);
        return Ok(result);
    }

    // GET /api/students?pageNumber=1&pageSize=10
    [HttpGet("/api/Students/Pagination")]
    public async Task<ActionResult<object>> GetStudents(int pageNumber = 1, int pageSize = 10)
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students
                                   .Include(s => s.Class)
                                   .ToList();
            return Ok(students);
        }

        [HttpGet("/api/classes/{classId}/students")]
        public IActionResult GetStudentsByClass(int classId)
        {
            var students = _context.Students
                                   .Where(s => s.classid == classId)
                                   .Include(s => s.Class)
                                   .ToList();

            if (!students.Any())
                return NotFound(new { message = "Không tìm thấy sinh viên nào trong lớp này." });

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students
                                  .Include(s => s.Class)
                                  .FirstOrDefault(s => s.id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            var existingClass = _context.Classes.Find(model.classid);
            if (existingClass == null)
            {
                return BadRequest(new { message = "Lớp không tồn tại." });
            }

            _context.Students.Add(model);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = model.id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student model)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            model.classid = student.classid;

            student.Name = model.Name;
            student.dateofbirth = model.dateofbirth;
            _context.SaveChanges();

            return NoContent();
        }
    }
    //  DELETE /api/students/{id} - Xóa sinh viên
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteStudent(int id)
    // {
    //     var existing = await _context.Students.FindAsync(id);
    //     if (existing == null)
    //         return NotFound("Không tìm thấy sinh viên để xóa.");

    //     _context.Students.Remove(existing);
    //     await _context.SaveChangesAsync();

    //     return Ok($"Đã xóa sinh viên có Id = {id}.");
    // }
}

using BackendMidterm.Data;
using BackendMidterm.Models;
using BackendMidterm.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BackendMidterm.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(AppDbContext context, IMapper mapper) : ControllerBase
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
        var totalCount = await _context.Students.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var students = await _context.Students
            .Include(s => s.Class)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var data = _mapper.Map<IEnumerable<StudentDto>>(students);

        return Ok(new
        {
            TotalItems = totalCount,
            TotalPages = totalPages,
            PageNumber = pageNumber,
            PageSize = pageSize,
            Data = data
        });
    }

    // POST /api/students
    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentDto dto)
    {
        var classExists = await _context.Classes.AnyAsync(c => c.Id == dto.ClassId);
        if (!classExists) return BadRequest("ClassId không tồn tại");

        var student = _mapper.Map<Student>(dto);
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        await _context.Entry(student).Reference(s => s.Class).LoadAsync();

        return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, _mapper.Map<StudentDto>(student));
    }

    // GET /api/classes/{classId}/students
    [HttpGet("/api/classes/{classId}/students")]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsByClass(int classId)
    {
        var students = await _context.Students
            .Include(s => s.Class)
            .Where(s => s.ClassId == classId)
            .ToListAsync();

        return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
    }

    // PUT /api/students/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, CreateStudentDto dto)
    {
        var existing = await _context.Students.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Name = dto.Name;
        existing.DateOfBirth = dto.DateOfBirth;
        // Không cho đổi lớp → giữ nguyên ClassId

        await _context.SaveChangesAsync();
        return NoContent();
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
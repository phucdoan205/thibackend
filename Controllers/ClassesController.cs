using BackendMidterm.Data;
using BackendMidterm.Models;
using BackendMidterm.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BackendMidterm.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController(AppDbContext context, IMapper mapper) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    // GET /api/classes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassDto>>> GetClasses()
    {
        var classes = await _context.Classes.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ClassDto>>(classes));
    }

    // POST /api/classes
    [HttpPost]
    public async Task<ActionResult<ClassDto>> CreateClass(ClassDto dto)
    {
        var c = new Class { Name = dto.Name };
        _context.Classes.Add(c);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClasses), new { id = c.Id }, _mapper.Map<ClassDto>(c));
    }
     //  PUT /api/classes/{id} - Cập nhật tên lớp
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateClass(int id, ClassDto dto)
    // {
    //     var existing = await _context.Classes.FindAsync(id);
    //     if (existing == null)
    //         return NotFound("Không tìm thấy lớp cần cập nhật.");

    //     existing.Name = dto.Name;
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

    // //  DELETE /api/classes/{id} - Xóa lớp (và sinh viên trong lớp đó)
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteClass(int id)
    // {
    //     var existing = await _context.Classes
    //         .Include(c => c.Students)
    //         .FirstOrDefaultAsync(c => c.Id == id);

    //     if (existing == null)
    //         return NotFound("Không tìm thấy lớp để xóa.");

    //     // Xóa sinh viên thuộc lớp này trước (nếu có)
    //     if (existing.Students != null && existing.Students.Any())
    //     {
    //         _context.Students.RemoveRange(existing.Students);
    //     }

    //     _context.Classes.Remove(existing);
    //     await _context.SaveChangesAsync();

    //     return Ok($"Đã xóa lớp {existing.Name} và toàn bộ sinh viên trong lớp.");
    // }
}

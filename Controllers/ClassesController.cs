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
}

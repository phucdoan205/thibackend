namespace BackendMidterm.Dtos;

public class StudentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string ClassName { get; set; }
}
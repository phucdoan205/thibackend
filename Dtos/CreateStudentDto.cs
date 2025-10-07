namespace BackendMidterm.Dtos;

public class CreateStudentDto
{
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int ClassId { get; set; }  // FK
}

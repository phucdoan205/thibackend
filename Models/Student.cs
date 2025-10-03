namespace BackendMidterm.Models;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int ClassId { get; set; }
    public required Class Class { get; set; }
}

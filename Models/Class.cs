namespace BackendMidterm.Models;

public class Class
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}

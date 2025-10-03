namespace BackendMidterm.Models;

public class Class
{
    public int id { get; set; }
    public string name { get; set; }
    public ICollection<Student>? Students { get; set; }
}

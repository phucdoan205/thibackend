namespace BackendMidterm.Models;

public class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime date_of_birth { get; set; }

    public int class_id { get; set; }
    public Class? Class { get; set; }
}

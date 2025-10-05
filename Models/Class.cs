namespace ClassModel
{
    public class Class
    {
        public int Id { get; set; }       

        public string Name { get; set; }     

        public ICollection<Student> Students { get; set; } = new LinkedList<Student>();
    }
}
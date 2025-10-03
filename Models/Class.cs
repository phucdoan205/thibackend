namespace thibackend
{
    public class Class
    {
        public int id { get; set; }       

        public string name { get; set; }     

        public ICollection<Student> students { get; set; } = new LinkedList<Student>();
    }
}
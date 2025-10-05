namespace StudentModel
{
    public class Student
    {
        public int Id { get; set; }           

        public string Name { get; set; }      

        public DateTime DateOfBirth { get; set; } 

        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
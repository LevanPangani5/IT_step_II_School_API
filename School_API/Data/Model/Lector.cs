namespace School_API.Data.Model
{
    public class Lector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

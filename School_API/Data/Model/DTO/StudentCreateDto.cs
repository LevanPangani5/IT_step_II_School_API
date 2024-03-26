namespace School_API.Data.Model.DTO
{
    public class StudentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Grade { get; set; }
    }
}

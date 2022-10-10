namespace TheUniversity.Models
{
    public class SubjectResult
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ResultGrade Grade { get; set; }
    }
}

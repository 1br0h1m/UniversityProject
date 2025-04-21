namespace UniversityProjectMVC.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int QuestionId { get; set; }
    }
}
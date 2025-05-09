namespace UniversityProjectMVC.Models
{
    public class Question
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<Answer> Answers { get; set; } = [];
        public int TestId { get; set; }
        public required string CorrectAnswerTitle { get; set; }
    }
}
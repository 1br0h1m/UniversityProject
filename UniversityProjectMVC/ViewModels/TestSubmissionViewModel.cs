namespace UniversityProjectMVC.ViewModels;

public class TestSubmissionViewModel
{
    public int TestId { get; set; }
    public string TestTitle { get; set; }
    public List<QuestionWithAnswers> Questions { get; set; }
    public Dictionary<int, int> SelectedAnswers { get; set; } = new();
}
using Microsoft.AspNetCore.Routing.Constraints;

namespace UniversityProjectMVC.Models;
public class Submission
{
    public int TestId;
    public required string ChoosenAnswer;
    public int QuestionNumber;
}
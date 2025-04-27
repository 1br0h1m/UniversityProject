using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProjectWPF.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<string> Answers { get; set; } = [];
        public TestViewModel? TestViewModel { get; set; }
        public required string CorrectAnswerTitle { get; set; }
    }
}

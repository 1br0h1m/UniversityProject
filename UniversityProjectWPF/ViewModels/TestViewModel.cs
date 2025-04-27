using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProjectWPF.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required SubjectViewModel Subject { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = [];
    }
}

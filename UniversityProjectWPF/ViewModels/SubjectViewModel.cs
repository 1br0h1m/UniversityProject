using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProjectWPF.ViewModels
{
    internal class SubjectViewModel
    {
        public int Id;
        public required string Name { get; set; }
        public List<TestViewModel> Tests { get; set; } = [];
    }
}

namespace UniversityProjectMVC.Models
{
    public class Subject
    {
        public int Id { get; set; }
        //public int GroupSubjectId { get; set; }
        public string Name { get; set; }
        public List<Test> Tests { get; set; } = [];
    }
}
namespace UniversityProjectMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int TeacherGroupId { get; set; }
        public int FacultyId { get; set; }
        public int MajorId { get; set; }
        public int SubjectId { get; set; } 

        public TeacherGroup TeacherGroup { get; set; }
        public Faculty Faculty { get; set; }
        public Major Major { get; set; }
        public Subject Subject { get; set; } 
    }
}

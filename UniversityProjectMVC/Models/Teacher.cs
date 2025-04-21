namespace UniversityProjectMVC.Models;

    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int TeacherGroupId { get; set; }
        public int DegreeId { get; set; }     
        public int FacultyId { get; set; }    

        public TeacherGroup TeacherGroup { get; set; }
        public Degree Degree { get; set; }
        public Faculty Faculty { get; set; }
    }


namespace UniversityProjectMVC.Models;

    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int GroupId { get; set; }
        public int DegreeId { get; set; }     
        public int FacultyId { get; set; }    

        public Group Group { get; set; }
        public Degree Degree { get; set; }
        public Faculty Faculty { get; set; }
        public string? ProfilePictureUrl { get; set; }

    }


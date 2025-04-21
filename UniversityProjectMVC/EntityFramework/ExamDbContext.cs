using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.Models;

namespace UniversityProjectMVC.EntityFramework
{
    public class ExamDbContext(DbContextOptions<ExamDbContext> options) : DbContext(options)
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.Models;

namespace UniversityProjectMVC.Data;

    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }


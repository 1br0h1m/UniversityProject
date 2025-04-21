using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UniversityProjectMVC.Data;

namespace UniversityProjectMVC.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly UniversityDbContext _context;

        public StudentController(UniversityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile()
        {
            var username = User.Identity?.Name;

            var student = await _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Major)
                .Include(s => s.TeacherGroup)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => (s.Surname + s.Name) == username);

            if (student == null)
                return NotFound("Student not found.");

            return View(student);
        }

        public IActionResult Group()
        {
            return View(); 
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

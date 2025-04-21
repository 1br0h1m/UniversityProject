using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UniversityProjectMVC.Data;

namespace UniversityProjectMVC.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly UniversityDbContext _context;

        public TeacherController(UniversityDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Groups()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var username = User.Identity?.Name;

            // Find the teacher by matching the User.Username == Teacher.Surname + Teacher.Name
            var teacher = await _context.Teachers
                .Include(t => t.Faculty)
                .Include(t => t.Degree)
                .Include(t => t.TeacherGroup)
                .FirstOrDefaultAsync(t => (t.Surname + t.Name) == username);

            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            return View(teacher);
        }
    }
}

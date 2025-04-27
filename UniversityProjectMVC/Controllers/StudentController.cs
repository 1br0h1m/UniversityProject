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
        private readonly BlobService _blobService;


        public StudentController(UniversityDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<IActionResult> Profile()
        {
            var username = User.Identity?.Name;

            var student = await _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Major)
                .Include(s => s.Group)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => (s.Name + s.Surname) == username);

            if (student == null)
                return NotFound("Student not found.");

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile profilePicture)
        {
            var username = User.Identity?.Name;
            var student = await _context.Students.FirstOrDefaultAsync(s => (s.Name + s.Surname) == username);

            if (student == null)
                return NotFound();

            if (profilePicture != null)
            {
                string fileName = $"{student.Name}_{student.Surname}_{DateTime.UtcNow.Ticks}{Path.GetExtension(profilePicture.FileName)}";
                var imageUrl = await _blobService.UploadFileAsync(profilePicture, fileName);
                student.ProfilePictureUrl = imageUrl;
                await _context.SaveChangesAsync();
            }

            TempData["Success"] = "Profile picture updated!";

            return RedirectToAction("Profile");
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

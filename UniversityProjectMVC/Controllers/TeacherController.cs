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

        private readonly BlobService _blobService;
        private readonly UniversityDbContext _context;

        public TeacherController(UniversityDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
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

            var teacher = await _context.Teachers
                .Include(t => t.Faculty)
                .Include(t => t.Degree)
                .Include(t => t.Group)
                .FirstOrDefaultAsync(t => (t.Name + t.Surname) == username);

            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile profilePicture)
        {
            var username = User.Identity?.Name;
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => (t.Name + t.Surname) == username);

            if (teacher == null)
                return NotFound();

            if (profilePicture != null)
            {
               string fileName = $"{teacher.Name}_{teacher.Surname}_{DateTime.UtcNow.Ticks}{Path.GetExtension(profilePicture.FileName)}";
               var imageUrl = await _blobService.UploadFileAsync(profilePicture, fileName);
             teacher.ProfilePictureUrl = imageUrl;
             await _context.SaveChangesAsync();
            }

            TempData["Success"] = "Profile picture updated!";

            return RedirectToAction("Profile");
        }

    }
}

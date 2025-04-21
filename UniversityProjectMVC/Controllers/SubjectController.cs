using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Services;

namespace UniversityProjectMVC.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    public class SubjectController(SubjectService service) : Controller
    {
        readonly SubjectService service = service;

        [HttpGet]
        public async Task<ActionResult> Index(string? searchInput)
        {
            try
            {
                var response = await (searchInput == null ? service.Get() : service.Get(searchInput));
                return View(response);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Subject subject)
        {
            try
            {
                var response = await service.Create(subject);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }
    }
}
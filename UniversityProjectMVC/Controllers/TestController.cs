using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Services;

namespace UniversityProjectMVC.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    public class TestController(TestService testService, SubjectService subjectService) : Controller
    {
        readonly TestService testService = testService;

        [HttpGet]
        public async Task<ActionResult> Index(string? searchInput)
        {
            try
            {
                var response = await (searchInput == null ? testService.Get() : testService.Get(searchInput));
                return View(response);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var subjects = await subjectService.Get();
            ViewData["Subjects"] = subjects;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Test test)
        {
            try
            {
                var response = await testService.Create(test);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Pass(int id, int questionNumber = 1) {
            ViewData["Answers"] = new List<string>();
            ViewData["QuestionNumber"] = questionNumber;
            var tests = testService.Get(id);
            return View(tests);
        }
        [HttpPost]
        public async Task<ActionResult> SubmitAnswer([FromForm] Submission submission) {
            var answers = ViewData["Answers"] as List<String>;
            answers?.Add(submission.ChoosenAnswer);
            ViewData["Answers"] = answers;
            return RedirectToAction($"pass/{submission.TestId}", submission.QuestionNumber + 1);
        }
    }
}
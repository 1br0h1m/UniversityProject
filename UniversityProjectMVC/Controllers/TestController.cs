using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Services;
using UniversityProjectMVC.ViewModels;

namespace UniversityProjectMVC.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    public class TestController(QuestionService questionService, TestService testService, SubjectService subjectService) : Controller
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

        public async Task<ActionResult> Take(int id)
        {
            var test = await testService.Get(id);

            if (test == null)
                return NotFound();

            var viewModel = new TestSubmissionViewModel
            {
                TestId = test.Id,
                TestTitle = test.Title,
                Questions = test.Questions.Select(q => new QuestionWithAnswers
                {
                    QuestionId = q.Id,
                    QuestionText = q.Title,
                    Answers = q.Answers.ToList()
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(TestSubmissionViewModel model)
        {
            int correctCount = 0;

            foreach (var entry in model.SelectedAnswers)
            {
                var question = await questionService.Get(entry.Key);
                var answer = question?.Answers?.FirstOrDefault(a => a.Id == entry.Value);

                if (answer != null && answer.Title == question.CorrectAnswerTitle)
                    correctCount++;
            }

            ViewBag.CorrectAnswers = correctCount;
            ViewBag.TotalQuestions = model.SelectedAnswers.Count;

            return View("Result");
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Services;

namespace UniversityProjectMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class QuestionController(QuestionService questionService, TestService testService) : Controller
    {
        readonly QuestionService questionService = questionService;
        readonly TestService testService = testService;

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var response = await questionService.Get();
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
            var tests = await testService.Get();
            ViewData["Tests"] = tests;

            var model = new Question
            {
                Title = "",
                Answers = [
                    new() { Title = "" },
                    new() { Title = "" },
                    new() { Title = "" }
                ],
                CorrectAnswerTitle = ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Question question)
        {
            try
            {
                var correctIndex = int.Parse(Request.Form["CorrectIndex"]);
                question.CorrectAnswerTitle = question.Answers[correctIndex].Title;

                var response = await questionService.Create(question);
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
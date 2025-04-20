using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniversityProjectMVC.Data;
using UniversityProjectMVC.Models;

public class IdentityController : Controller
{
    private readonly UniversityDbContext _context;

    public IdentityController(UniversityDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u =>
            u.Username == username && u.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(principal);

        return user.Role switch
        {
            "Admin" => RedirectToAction("Index", "Admin"),
            "Teacher" => RedirectToAction("Index", "Teacher"),
            "Student" => RedirectToAction("Index", "Student"),
            _ => RedirectToAction("Login")
        };
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}

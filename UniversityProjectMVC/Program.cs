using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.EntityFramework;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Repositories;
using UniversityProjectMVC.Services;
using UniversityProjectMVC.Validators;
using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.Data; 
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("TestsDb")!;

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Identity/Login";
    options.AccessDeniedPath = "/Identity/AccessDenied";
});

builder.Services.AddScoped<TestRepository>();
builder.Services.AddScoped<TestService>();
builder.Services.AddScoped<SubjectRepository>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<QuestionRepository>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddDbContext<ExamDbContext>(options =>
                options.UseNpgsql(connectionString));
builder.Services.AddScoped<IValidator<Question>, QuestionValidator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

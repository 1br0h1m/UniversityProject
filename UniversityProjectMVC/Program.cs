using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.EntityFramework;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Repositories;
using UniversityProjectMVC.Services;
using UniversityProjectMVC.Validators;
using UniversityProjectMVC.Data; 
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
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
builder.Services.AddSingleton(new BlobService(
    builder.Configuration.GetConnectionString("AzureBlobStorage"), 
    "profilepictures" 
));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = serviceScopeFactory.CreateScope())
{
    var universityDbContext = scope.ServiceProvider.GetService<UniversityDbContext>();
    var examDbContext = scope.ServiceProvider.GetService<ExamDbContext>();
    try
    {
        universityDbContext?.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"UniversityDbContext migration error: {ex.Message}");
        universityDbContext?.Database.EnsureCreated();
    }

    try
    {
        examDbContext?.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ExamDbContext migration error: {ex.Message}");
        examDbContext?.Database.EnsureCreated();
    }
}

app.Run();

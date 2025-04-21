using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.EntityFramework;
using UniversityProjectMVC.Models;
namespace UniversityProjectMVC.Repositories
{
    public class TestRepository(ExamDbContext context)
    {
        readonly ExamDbContext context = context;
        public async Task<Test> Create(Test test)
        {
            await context.Tests
                .AddAsync(test);
            await context.SaveChangesAsync();
            return test;
        }
        public async Task<List<Test>> Get()
        {
            var test = await context.Tests
                .AsNoTracking()
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
            return test;
        }
        public async Task<Test?> Get(int id)
        {
            var test = await context.Tests
                .AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == id);
            return test;
        }
        public async Task<List<Test>> Get(string title)
        {
            var tests = await context.Tests
                .AsNoTracking()
                .Where(t => t.Title.Contains(title))
                .ToListAsync();
            return tests;
        }
        public async Task<bool> Update(Test test)
        {
            context.Update(test);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(Test test)
        {
            context.Remove(test);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
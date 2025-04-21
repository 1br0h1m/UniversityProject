using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.EntityFramework;
using UniversityProjectMVC.Models;
namespace UniversityProjectMVC.Repositories
{
    public class QuestionRepository(ExamDbContext context)
    {
        readonly ExamDbContext context = context;
        public async Task<Question> Create(Question question)
        {
            await context.Questions
                .AddAsync(question);
            await context.SaveChangesAsync();
            return question;
        }
        public async Task<List<Question>> Get()
        {
            var questions = await context.Questions
                .AsNoTracking()
                .Include(q => q.Answers)
                .ToListAsync();
            return questions;
        }
        public async Task<Question?> Get(int id)
        {
            var question = await context.Questions
                .AsNoTracking()
                .Include(q => q.Answers)
                .SingleOrDefaultAsync(q => q.Id == id);
            return question;
        }
        public async Task<List<Question>> Get(string title)
        {
            var questions = await context.Questions
                .AsNoTracking()
                .Where(q => q.Title.Contains(title))
                .ToListAsync();
            return questions;
        }
        public async Task<bool> Update(Question question)
        {
            context.Update(question);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(Question question)
        {
            context.Remove(question);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
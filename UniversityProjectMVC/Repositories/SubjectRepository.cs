using Microsoft.EntityFrameworkCore;
using UniversityProjectMVC.EntityFramework;
using UniversityProjectMVC.Models;
namespace UniversityProjectMVC.Repositories
{
    public class SubjectRepository(ExamDbContext context)
    {
        readonly ExamDbContext context = context;
        public async Task<Subject> Create(Subject subject)
        {
            await context.Subjects
                .AddAsync(subject);
            await context.SaveChangesAsync();
            return subject;
        }
        public async Task<List<Subject>> Get()
        {
            var subjects = await context.Subjects
                .AsNoTracking()
                .ToListAsync();
            return subjects;
        }
        public async Task<Subject?> Get(int id)
        {
            var subjects = await context.Subjects
                .AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == id);
            return subjects;
        }
        public async Task<List<Subject>> Get(string name)
        {
            var subjects = await context.Subjects
                .AsNoTracking()
                .Where(s => s.Name.Contains(name))
                .ToListAsync();
            return subjects;
        }
        public async Task<bool> Update(Subject subject)
        {
            context.Update(subject);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(Subject subject)
        {
            context.Remove(subject);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
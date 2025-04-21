using FluentValidation;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Repositories;

namespace UniversityProjectMVC.Services;
public class QuestionService(QuestionRepository repository, IValidator<Question> validator)
{
    readonly IValidator<Question> validator = validator;
    readonly QuestionRepository repository = repository;
    public async Task<Question> Create(Question question)
    {
        await validator.ValidateAndThrowAsync(question);
        return await repository.Create(question);
    }
    public async Task<List<Question>> Get()
    {
        return await repository.Get();
    }
    public async Task<Question?> Get(int id)
    {
        return await repository.Get(id);
    }
    public async Task<List<Question>> Get(string title)
    {
        return await repository.Get(title);
    }
    public async Task<bool> Update(Question question)
    {
        await validator.ValidateAndThrowAsync(question);
        return await repository.Update(question);
    }
    public async Task<bool> Delete(Question question)
    {
        return await repository.Delete(question);
    }
}
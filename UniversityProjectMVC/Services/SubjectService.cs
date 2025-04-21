using FluentValidation;
using UniversityProjectMVC.Models;
using UniversityProjectMVC.Repositories;

namespace UniversityProjectMVC.Services;
public class SubjectService(SubjectRepository repository)
{    readonly SubjectRepository repository = repository;
    public async Task<Subject> Create(Subject subject)
    {
        return await repository.Create(subject);
    }
    public async Task<List<Subject>> Get()
    {
        return await repository.Get();
    }
    public async Task<Subject?> Get(int id)
    {
        return await repository.Get(id);
    }
    public async Task<List<Subject>> Get(string title)
    {
        return await repository.Get(title);
    }
    public async Task<bool> Update(Subject subject)
    {
        return await repository.Update(subject);
    }
    public async Task<bool> Delete(Subject subject)
    {
        return await repository.Delete(subject);
    }
}
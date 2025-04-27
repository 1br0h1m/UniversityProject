using FluentValidation;
using Microsoft.IdentityModel.Tokens;
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
    public async Task<bool> Update(Subject newSubjectData)
    {
        var subject = await repository.Get(newSubjectData.Id) ?? throw new KeyNotFoundException();
        subject.Name = !newSubjectData.Name.IsNullOrEmpty() ? newSubjectData.Name : subject.Name;
        subject.Tests = !newSubjectData.Tests.IsNullOrEmpty() ? newSubjectData.Tests : subject.Tests;
        return await repository.Update(subject);
    }
    public async Task<bool> Delete(int id)
    {
        var subject = await repository.Get(id) ?? throw new KeyNotFoundException();
        return await repository.Delete(subject);
    }
}
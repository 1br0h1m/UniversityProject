using UniversityProjectMVC.Models;
using UniversityProjectMVC.Repositories;

namespace UniversityProjectMVC.Services;
public class TestService(TestRepository repository)
{
    readonly TestRepository repository = repository;
    public async Task<Test> Create(Test test)
    {
        return await repository.Create(test);
    }
    public async Task<List<Test>> Get()
    {
        return await repository.Get();
    }
    public async Task<Test?> Get(int id)
    {
        return await repository.Get(id);
    }
    public async Task<List<Test>> Get(string title)
    {
        return await repository.Get(title);
    }
    public async Task<bool> Update(Test test)
    {
        return await repository.Update(test);
    }
    public async Task<bool> Delete(Test test)
    {
        return await repository.Delete(test);
    }
}
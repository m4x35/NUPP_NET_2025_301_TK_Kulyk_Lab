using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Repositories;

namespace SimpleLibrary.Infrastructure.Services;

public class DatabaseCrudServiceAsync
{
    private readonly IRepository<BookModel> _repository;

    public DatabaseCrudServiceAsync(IRepository<BookModel> repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAsync(BookModel element)
    {
        await _repository.AddAsync(element);
        return true;
    }

    public async Task<BookModel?> ReadAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BookModel>> ReadAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<BookModel>> ReadAllAsync(int page, int amount)
    {
        var items = await _repository.GetAllAsync();

        return items
            .Skip((page - 1) * amount)
            .Take(amount);
    }

    public async Task<bool> UpdateAsync(BookModel element)
    {
        await _repository.Update(element);
        return true;
    }

    public async Task<bool> RemoveAsync(BookModel element)
    {
        await _repository.Delete(element);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        return Task.FromResult(true);
    }
}
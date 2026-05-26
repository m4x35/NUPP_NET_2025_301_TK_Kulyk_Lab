using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Repositories;

namespace SimpleLibrary.Infrastructure.Services;

public class DatabaseCrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
{
    private readonly IRepository<T> _repository;

    public DatabaseCrudServiceAsync(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAsync(T element)
    {
        await _repository.AddAsync(element);
        return true;
    }

    public async Task<T?> ReadAsync(Guid id)
    {
        var items = await _repository.GetAllAsync();

        return items.FirstOrDefault(x =>
        {
            var prop = x.GetType().GetProperty("OriginalId");
            return prop != null && (Guid)prop.GetValue(x)! == id;
        });
    }

    public async Task<IEnumerable<T>> ReadAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        var items = await _repository.GetAllAsync();

        return items
            .Skip((page - 1) * amount)
            .Take(amount);
    }

    public async Task<bool> UpdateAsync(T element)
    {
        await _repository.Update(element);
        return true;
    }

    public async Task<bool> RemoveAsync(T element)
    {
        await _repository.Delete(element);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        return Task.FromResult(true);
    }
}
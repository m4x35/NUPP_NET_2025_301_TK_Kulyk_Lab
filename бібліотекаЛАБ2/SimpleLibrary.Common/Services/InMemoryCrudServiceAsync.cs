using System.Collections;
using System.Text.Json;
using SimpleLibrary.Common.Models;

namespace SimpleLibrary.Common.Services;

public class InMemoryCrudServiceAsync<T> : ICrudServiceAsync<T>
    where T : class, IEntity
{
    private readonly List<T> _items = new();

    // приклад Lock
    private readonly object _lock = new();

    // приклад Semaphore
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public string FilePath { get; }

    // конструктор
    public InMemoryCrudServiceAsync(string filePath)
    {
        FilePath = filePath;
    }

    public async Task<bool> CreateAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            lock (_lock)
            {
                _items.Add(element);
            }

            return true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public Task<T?> ReadAsync(Guid id)
    {
        lock (_lock)
        {
            return Task.FromResult(_items.FirstOrDefault(x => x.Id == id));
        }
    }

    public Task<IEnumerable<T>> ReadAllAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_items.ToList().AsEnumerable());
        }
    }

    public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        lock (_lock)
        {
            var result = _items
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToList()
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }

    public async Task<bool> UpdateAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            lock (_lock)
            {
                var index = _items.FindIndex(x => x.Id == element.Id);

                if (index == -1)
                    return false;

                _items[index] = element;
                return true;
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<bool> RemoveAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            lock (_lock)
            {
                return _items.Remove(element);
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<bool> SaveAsync()
    {
        await _semaphore.WaitAsync();

        try
        {
            List<T> copy;

            lock (_lock)
            {
                copy = _items.ToList();
            }

            var json = JsonSerializer.Serialize(copy, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(FilePath, json);

            return true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        lock (_lock)
        {
            return _items.ToList().GetEnumerator();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
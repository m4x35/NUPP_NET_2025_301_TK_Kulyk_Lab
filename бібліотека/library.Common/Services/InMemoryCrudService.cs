using SimpleLibrary.Common.Models;

namespace SimpleLibrary.Common.Services;

// делегат
public delegate void CrudMessage(string message);

public class InMemoryCrudService<T> : ICrudService<T> where T : class, IEntity
{
    private readonly List<T> _items = new();

    // подія
    public event CrudMessage? OnAction;

    // статичне поле
    public static int CreatedCount;

    // статичний конструктор
    static InMemoryCrudService()
    {
        CreatedCount = 0;
    }

    // метод Create
    public void Create(T element)
    {
        _items.Add(element);
        CreatedCount++;
        OnAction?.Invoke($"Created element with Id: {element.Id}");
    }

    // метод Read
    public T Read(Guid id)
    {
        return _items.First(x => x.Id == id);
    }

    // метод ReadAll
    public IEnumerable<T> ReadAll()
    {
        return _items;
    }

    // метод Update
    public void Update(T element)
    {
        var index = _items.FindIndex(x => x.Id == element.Id);
        if (index >= 0)
        {
            _items[index] = element;
            OnAction?.Invoke($"Updated element with Id: {element.Id}");
        }
    }

    // метод Remove
    public void Remove(T element)
    {
        _items.Remove(element);
        OnAction?.Invoke($"Removed element with Id: {element.Id}");
    }

    // статичний метод
    public static void PrintCreatedCount()
    {
        Console.WriteLine($"Total created elements: {CreatedCount}");
    }
}

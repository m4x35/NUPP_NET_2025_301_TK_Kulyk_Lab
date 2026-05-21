using SimpleLibrary.Common.Models;

namespace SimpleLibrary.Common.Services;

public interface ICrudService<T> where T : IEntity
{
    void Create(T element);
    T Read(Guid id);
    IEnumerable<T> ReadAll();
    void Update(T element);
    void Remove(T element);
}

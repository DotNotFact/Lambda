using System.Collections.ObjectModel;

namespace LambdaUI.Repositories;

public interface IRepository<T> where T : class
{
    ObservableCollection<T> GetAll();
    void Add(T item);
    void Update(T item);
    void Delete(Guid id);
}

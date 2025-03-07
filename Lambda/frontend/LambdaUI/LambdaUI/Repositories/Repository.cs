using System.Collections.ObjectModel;
using LambdaUI.Services;

namespace LambdaUI.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    public ObservableCollection<T> GetAll()
    {
        return LocalStorageService.GetCollection<T>();
    }

    public void Add(T item)
    {
        var collection = LocalStorageService.GetCollection<T>();
        collection.Add(item);
        LocalStorageService.SaveChanges();
    }

    public void Update(T item)
    {
        var collection = LocalStorageService.GetCollection<T>();
        var existing = collection.FirstOrDefault(x => ((dynamic)x).Uid == ((dynamic)item).Uid);
        if (existing != null)
        {
            // Обновление свойств
            foreach (var prop in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                prop.SetValue(existing, prop.GetValue(item));
            }
        }
        LocalStorageService.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var collection = LocalStorageService.GetCollection<T>();
        var item = collection.FirstOrDefault(x => ((dynamic)x).Uid == id);
        if (item != null)
        {
            collection.Remove(item);
            LocalStorageService.SaveChanges();
        }
    }
}

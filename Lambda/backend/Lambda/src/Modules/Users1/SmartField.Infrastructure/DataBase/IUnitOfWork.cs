namespace Lambda.Modules.Users.Infrastructure.DataBase;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

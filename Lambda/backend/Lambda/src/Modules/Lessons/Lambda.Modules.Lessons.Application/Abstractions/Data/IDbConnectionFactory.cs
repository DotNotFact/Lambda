using System.Data.Common;

namespace Lambda.Modules.Lessons.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}

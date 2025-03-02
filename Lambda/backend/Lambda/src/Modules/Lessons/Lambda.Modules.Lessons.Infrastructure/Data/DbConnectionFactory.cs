using Lambda.Modules.Lessons.Application.Abstractions.Data;
using System.Data.Common;
using Npgsql;

namespace Lambda.Modules.Lessons.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}

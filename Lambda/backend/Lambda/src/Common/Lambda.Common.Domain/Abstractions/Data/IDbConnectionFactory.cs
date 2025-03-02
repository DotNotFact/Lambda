using System.Data.Common;

namespace Lambda.Common.Domain.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}

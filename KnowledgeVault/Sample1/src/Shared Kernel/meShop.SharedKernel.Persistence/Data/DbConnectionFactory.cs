using meShop.SharedKernel.Core.Data;
using Npgsql;
using System.Data.Common;

namespace meShop.SharedKernel.Persistence.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
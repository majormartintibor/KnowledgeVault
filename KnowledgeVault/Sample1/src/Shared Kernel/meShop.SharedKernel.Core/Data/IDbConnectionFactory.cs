using System.Data.Common;

namespace meShop.SharedKernel.Core.Data;
public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
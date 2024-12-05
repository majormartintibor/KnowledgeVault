using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Exceptions;
public sealed class MeShopException(string requestName, Error? error = default, Exception? innerException = default) 
    : Exception("Application exception", innerException) 
{
    public string RequestName { get; } = requestName;
    public Error? Error { get; } = error;
}

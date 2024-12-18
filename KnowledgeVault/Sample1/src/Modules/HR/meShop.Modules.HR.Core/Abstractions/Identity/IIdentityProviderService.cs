using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Abstractions.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
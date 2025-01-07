using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.RegisterEmployee;

public sealed record RegisterEmployeeCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : ICommand<Guid>;

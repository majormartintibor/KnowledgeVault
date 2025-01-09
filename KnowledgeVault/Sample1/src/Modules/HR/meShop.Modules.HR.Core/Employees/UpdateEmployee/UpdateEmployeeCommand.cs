using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(Guid EmployeeId, string FirstName, string LastName) : ICommand;
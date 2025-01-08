using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.GetEmployee;

public sealed record GetEmployeeQuery(Guid EmployeeId) : IQuery<EmployeeResponse>;
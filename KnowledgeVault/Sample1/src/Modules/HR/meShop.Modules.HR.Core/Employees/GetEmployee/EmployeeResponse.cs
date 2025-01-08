namespace meShop.Modules.HR.Core.Employees.GetEmployee;

public sealed record EmployeeResponse(Guid EmployeeId, string Email, string FirstName, string LastName);
using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Employees.Domain;
public static class EmployeeErrors
{
    public static Error NotFound(Guid employeeId) =>
        Error.NotFound("Employees.NotFound", $"The employee with the identifier {employeeId} not found");

    public static Error NotFound(string identityId) =>
        Error.NotFound("Employees.NotFound", $"The employee with the IDP identifier {identityId} not found");
}
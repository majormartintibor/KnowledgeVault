using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Employees;
public static class EmployeeErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound("Employees.NotFound", $"The employee with the identifier {userId} not found");

    public static Error NotFound(string identityId) =>
        Error.NotFound("Employees.NotFound", $"The employee with the IDP identifier {identityId} not found");
}
using FluentValidation;

namespace meShop.Modules.HR.Core.Employees.UpdateEmployee;

internal sealed class UpdateEmployeeCommandValidator: AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(c => c.EmployeeId).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
    }
}
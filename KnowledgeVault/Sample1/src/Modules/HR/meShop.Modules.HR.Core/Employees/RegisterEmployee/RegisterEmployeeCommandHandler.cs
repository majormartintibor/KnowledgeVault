using meShop.Modules.HR.Core.Abstractions.Data;
using meShop.Modules.HR.Core.Abstractions.Identity;
using meShop.Modules.HR.Core.Employees.Domain;
using meShop.Modules.HR.Core.Employees.Ports.Incomming;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.RegisterEmployee;

internal sealed class RegisterEmployeeCommandHandler(
    IIdentityProviderService identityProviderService,
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork
    ) : ICommandHandler<RegisterEmployeeCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
    {
        Result<string> result = await identityProviderService.RegisterEmployeeAsync(
            new EmployeeModel(request.Email, request.Password, request.FirstName, request.LastName), 
             cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        var employee = Employee.Create(request.Email, request.FirstName, request.LastName, result.Value);

        employeeRepository.Insert(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
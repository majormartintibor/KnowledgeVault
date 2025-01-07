using MediatR;
using meShop.Modules.HR.Core.Employees.Domain;
using meShop.Modules.HR.Core.Employees.GetEmployeePermissions;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.EventBus;
using meShop.SharedKernel.Core.Exceptions;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.RegisterEmployee;

//internal sealed class EmployeeRegisteredDomainEventHandler(ISender sender, IEventBus eventBus)
//    : IDomainEventHandler<EmployeeRegisteredDomainEvent>
//{
//    public async Task Handle(EmployeeRegisteredDomainEvent notification, CancellationToken cancellationToken)
//    {
//        Result<EmployeeResponse> result = await sender.Send(new GetEmployeeQuery(notification.Id), cancellationToken);

//        if (result.IsFailure)
//        {
//            throw new MeShopException(nameof(GetEmployeeQuery), result.Error);
//        }

//        await eventBus.PublishAsync(
//            new EmployeeRegisteredIntegrationEvent(),
//            cancellationToken);
//    }
//}

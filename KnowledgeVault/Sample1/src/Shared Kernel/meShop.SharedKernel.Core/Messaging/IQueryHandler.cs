using MediatR;
using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
using MediatR;
using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
using MediatR;
using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
public interface IBaseCommand;
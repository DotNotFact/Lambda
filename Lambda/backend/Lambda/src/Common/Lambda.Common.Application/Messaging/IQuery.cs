using Lambda.Common.Domain;
using MediatR;

namespace Lambda.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

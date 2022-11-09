using MediatR;

namespace RecordStore.BusinessLogic.Wrappers.Result;

public interface IRequestHandlerResult<TIn, TOut> : IRequestHandler<TIn, Result<TOut>> where TIn : IRequest<Result<TOut>> { }
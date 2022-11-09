using MediatR;

namespace RecordStore.BusinessLogic.Wrappers.Result;

public interface IRequestResult<TOut> : IRequest<Result<TOut>> { }
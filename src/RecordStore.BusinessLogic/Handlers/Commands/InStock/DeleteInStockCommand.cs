using FluentValidation;
using RecordStore.BusinessLogic.Extensions;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Commands.InStock;

public class DeleteInStockCommand : IRequestResult<int>
{
    public int InStockId { get; set; }
}

public class DeleteInStockCommandValidator : AbstractValidator<DeleteInStockCommand>
{
    private const int MinIdValue = 0;
    
    public DeleteInStockCommandValidator()
    {
        RuleFor(x => x.InStockId)
            .GreaterThan(MinIdValue)
            .WithMessage($"InStockId have to be greater then '{MinIdValue}'");
    }
}

public class DeleteInStockCommandHandler : IRequestHandlerResult<DeleteInStockCommand, int>
{
    private readonly IInStockRepository _inStockRepository;

    private readonly IValidator<DeleteInStockCommand> _validator;

    public DeleteInStockCommandHandler(
        IValidator<DeleteInStockCommand> validator,
        IInStockRepository inStockRepository)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
    }
    
    public async Task<Result<int>> Handle(DeleteInStockCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail<int>(validationResult.GetErrorMessages());
        }
        
        var inStockExist = await _inStockRepository.ExistById(command.InStockId);
        if (!inStockExist)
        {
            return Result.Fail<int>($"Could not find inStock with Id = '{command.InStockId}'");
        }
        
        await _inStockRepository.DeleteAsync(command.InStockId);
        
        return Result.Success(command.InStockId);
    }
}
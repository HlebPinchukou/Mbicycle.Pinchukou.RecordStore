using FluentValidation;
using RecordStore.BusinessLogic.Extensions;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Commands.InStock;

public class UpdateInStockCommand : IRequestResult<int>
{
    public UpdateInStockCommand(
        int inStockId,
        int albumId, 
        string typeOfRecord,
        string album,
        decimal price)
    {
        InStockId = inStockId;
        AlbumId = albumId;
        Album = album;
        TypeOfRecord = typeOfRecord;
        Price = price;
    }

    public int InStockId { get; set; }

    public int AlbumId { get; }

    public string TypeOfRecord { get; }

    public string Album { get; }
    public Decimal Price { get; }
    
}

public class UpdateInStockCommandValidator : AbstractValidator<UpdateInStockCommand>
{
    private const int MinPositive = 0;
    
    public UpdateInStockCommandValidator()
    {
        RuleFor(x => x.AlbumId)
            .GreaterThan(MinPositive)
            .WithMessage($"AlbumId have to be greater then '{MinPositive}'");
            
        RuleFor(x => x.TypeOfRecord)
            .NotNull()
            .WithMessage($"Type Of Record have to not be empty");
            
        RuleFor(x => x.Price)
            .GreaterThan(MinPositive)
            .WithMessage($"Price have to be greater then '{MinPositive}'");

        RuleFor(x => x.Album)
            .NotNull()
            .WithMessage("Album have to not be empty");
    }
}

public class UpdateInStockCommandHandler : IRequestHandlerResult<UpdateInStockCommand, int>
{
    private readonly IValidator<UpdateInStockCommand> _validator;
    private readonly IInStockRepository _inStockRepository;

    public UpdateInStockCommandHandler(
        IValidator<UpdateInStockCommand> validator,
        IInStockRepository inStockRepository)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
    }
    
    public async Task<Result<int>> Handle(UpdateInStockCommand command, CancellationToken cancellationToken)
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

        var data = await _inStockRepository.UpdateAsync(
            command.AlbumId, 
            command.TypeOfRecord, 
            command.Album, 
            command.Price);
        
        return Result.Success(data);
    }
}
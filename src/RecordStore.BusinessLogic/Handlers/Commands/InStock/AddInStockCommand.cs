using FluentValidation;
using RecordStore.BusinessLogic.Extensions;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Commands.InStock;

public class AddInStockCommand : IRequestResult<int>
{
    public AddInStockCommand(
        int id,
        int albumId,
        string album,
        string typeOfRecord,
        decimal price)
    {
        AlbumId = albumId;
        TypeOfRecord = typeOfRecord;
        Price = price;
        Album = album;
    }

    public int AlbumId { get; }

    public string Album { get; }
   

    public string TypeOfRecord { get; }

    public decimal Price { get; }
}
    
public class AddInStockCommandValidator : AbstractValidator<AddInStockCommand>
{
    private const int MinPositive = 0;
    
    public AddInStockCommandValidator()
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

public class AddInStockCommandHandler : IRequestHandlerResult<AddInStockCommand, int>
{
    private readonly IValidator<AddInStockCommand> _validator;
    private readonly IAlbumRepository _albumRepository;
    private readonly IInStockRepository _inStockRepository;

    public AddInStockCommandHandler(
        IValidator<AddInStockCommand> validator,
        IAlbumRepository albumRepository,
        IInStockRepository inStockRepository)
    {
        _validator = validator;
        _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
        _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository)); ;
    }

    public async Task<Result<int>> Handle(AddInStockCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail<int>(validationResult.GetErrorMessages());
        }

        var albumExist = await _albumRepository.ExistById(command.AlbumId);
        if (!albumExist)
        {
            return Result.Fail<int>($"Could not find album with Id = '{command.AlbumId}'");
        }

        var data = await _inStockRepository
            .AddAsync(
                command.AlbumId, 
                command.TypeOfRecord, 
                command.Album, 
                command.Price);

        return Result.Success(data);
    }
}



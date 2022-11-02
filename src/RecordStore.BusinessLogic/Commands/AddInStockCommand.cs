using MediatR;
using RecordStore.BusinessLogic.Wrappers;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Commands
{
    public class AddInStockCommand : IRequest<Result<int>>
    {
        public AddInStockCommand(
            int id,
            int albumId,
            string album,
            string typeOfRecord,
            decimal price)
        {
            Id = id;
            AlbumId = albumId;
            TypeOfRecord = typeOfRecord;
            Price = price;
            Album = album;
        }

        public int Id { get; set; }

        public int AlbumId { get; set; }

        public string TypeOfRecord { get; set; }

        public decimal Price { get; set; }

        public string Album { get; set; }
    }

    public class AddInStockCommandHandler : IRequestHandler<AddInStockCommand, Result<int>>
    {
        private readonly IAlbumRepository _albumRepository;

        private readonly IInStockRepository _inStockRepository;

        public AddInStockCommandHandler(
            IAlbumRepository albumRepository,
            IInStockRepository inStockRepository)
        {
            _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository)); ;
            _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository)); ;
        }

        public Task<Result<int>> Handle(AddInStockCommand command, CancellationToken cancellationToken)
        {
            var album = _albumRepository.Get(command.AlbumId);

            if (album.Id != command.AlbumId)
            {
                return Result.FailAsync<int>($"Could not find album with Id = '{command.AlbumId}'");
            }

            var newSale = new InStock()
            {
                Album = album,
                TypeOfRecord = command.TypeOfRecord,
                Price = command.Price,
                AlbumId = command.AlbumId,
            };

            var result = _inStockRepository.Add(newSale);

            return Result.SuccessAsync(result.Id);
        }

    }
}
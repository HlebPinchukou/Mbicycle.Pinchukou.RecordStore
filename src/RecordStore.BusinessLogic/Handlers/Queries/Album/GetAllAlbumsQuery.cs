using RecordStore.BusinessLogic.Dto;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Queries
{
    public class GetAllAlbumsQuery : IRequestResult<IEnumerable<AlbumDto>>
    {
    }

    public class GetAllAlbumsQueryHandler : IRequestHandlerResult<GetAllAlbumsQuery, IEnumerable<AlbumDto>>
    {
        private readonly IAlbumRepository _albumRepository;

        public GetAllAlbumsQueryHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
        }

        public async Task<Result<IEnumerable<AlbumDto>>> Handle(GetAllAlbumsQuery request,
            CancellationToken cancellationToken)
        {
            var data = (await _albumRepository.GetAsync())
                .Select(p => new AlbumDto
                {
                    Id = p.Id,
                    Name = p.Name,
                });

            return Result.Success(data);
        }
    }
}
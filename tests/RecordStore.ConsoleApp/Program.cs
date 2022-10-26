using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;
using RecordStore.DataAccess.UnitOfWork;

using var context = new RecordStoreContext();

var unitOfWork = new UnitOfWork(context);
var albumRepo = new AlbumRepository(context);
var artistRepo = new ArtistRepository(context);
var stockRepo = new InStockRepository(context);

try
{
    unitOfWork.BeginTransaction();
    
    var moon = new Album { Name = "Man on the Moon" };
    var cudi = new Artist { Name = "Kid Cudi", Bio = "Some bio", Photo = "link to photo"};
    
    albumRepo.Add(moon);
    artistRepo.Add(cudi);

    //cudi = null;

    Console.WriteLine(cudi.Id);

    albumRepo.Add(new Album { Artist = cudi, Cover = "link_to_cover", YearOfRelease = DateTime.Now, Genre = "Rap" });
    stockRepo.Add(new InStock { TypeOfRecord = "vinyl", Price = 10, Album = moon });

    unitOfWork.CommitTransaction();
}
catch
{
    unitOfWork.RollbackTransaction();
}
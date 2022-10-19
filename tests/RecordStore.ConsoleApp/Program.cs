using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;

using (var context = new RecordStoreContext())
{
    var list = context.InStocks.Include(x => x.Album).ToList();

    var drake = new Album { Name = "Certified Lover Boy" };
    var cudi = new Album { Name = "Man on the Moon" };

    var albumRepository = new AlbumRepository(context);

    drake = albumRepository.Get(5);

    context.InStocks.Add(new InStock { TypeOfRecord = "Vinyl", Price = 5, Album = drake });

    context.SaveChanges();

    albumRepository.Delete(3);

    albumRepository.Add(drake);
    albumRepository.Add(cudi);


    foreach (var item in albumRepository.Get())
    {
        Console.WriteLine($"{item.Id} - {item.Name}");
    }

    var album = albumRepository.Get(1);
    Console.WriteLine($"{album.Id} - {album.Name}");

}
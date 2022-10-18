using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;

using (var context = new RecordStoreContext())
{
    var drake = new Album { Name = "Certified Lover Boy" };
    var cudi = new Album { Name = "Man on the Moon" };

    var albumRepository = new AlbumRepository(context);

    albumRepository.Add(cudi);
    albumRepository.Add(drake);

    foreach (var item in albumRepository.Get())
    {
        Console.WriteLine($"{item.Id} - {item.Name} ");
    }
}

using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;

using (var context = new RecordStoreContext())
{
    var drake = new Artist { Name = "Drake" };
    var cudi = new Artist { Name = "Kid Cudi" };

    var artistRepository = new ArtistRepository(context);

    artistRepository.Add(cudi);
    artistRepository.Add(drake);

    foreach (var item in artistRepository.Get())
    {
        Console.WriteLine($"{item.Id} - {item.Name} ");
    }
}

using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Context
{
    public sealed class RecordStoreContext: DbContext
    {
     public DbSet<InStock> InStocks { get; set; }
     public DbSet<Album> Albums { get; set; }
     public DbSet<Album> Artists { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
      optionsBuilder.UseSqlServer(@"Server=DESKTOP-FB3C9TG;Database=RecordStore;Trusted_Connection=True");
     }
    }
}

//DESKTOP-13E7H8C - р
//DESKTOP-FB3C9TG - д

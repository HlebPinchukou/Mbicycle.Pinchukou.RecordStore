using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordStore.DataAccess.Context
{
    public sealed class RecordStoreContext: DbContext
    {
     public DbSet<InStock> InStocks { get; set; }
     public DbSet<Album> Albums { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
      optionsBuilder.UseSqlServer(@"Server=PC\DESKTOP-FB3C9TG;Database=GamesLib;Trusted_Connection=True");
     }
    }
}

using RecordStore.DataAccess.Model.Base;

namespace RecordStore.DataAccess.Model
{
    public class InStock: Entity
    {
        public string TypeOfRecord { get; set; }
        
        public int AlbumId { get; set; }
        
        public Decimal Price { get; set; }
        
        public Album Album { get; set; }
    }
}

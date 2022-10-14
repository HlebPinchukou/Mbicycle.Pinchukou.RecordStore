namespace RecordStore.DataAccess.Model
{
    public class InStock: Base.Model
    {
        public string TypeOfRecord { get; set; }
        public int AlbumId { get; set; }
        public Decimal Price { get; set; }
        public Album Album { get; set; }
    }
}

namespace RecordStore.DataAccess.Model
{
    public class Album: Base.Model
    {
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime YearOfRelease { get; set; }
    }
}

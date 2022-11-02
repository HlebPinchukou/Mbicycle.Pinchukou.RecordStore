namespace RecordStore.BusinessLogic.Dto;

public class AlbumDto
{
    public int Id { get; set; }
    
    public string Genre { get; set; }
    
    public string Name { get; set; }
    
    public string Cover { get; set; }

    public int ArtistId { get; set; }
    
    public string Artist { get; set; }
    
    public DateTime YearOfRelease { get; set; }
    
}
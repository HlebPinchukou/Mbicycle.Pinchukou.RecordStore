namespace RecordStore.BusinessLogic.Dto;

public class InStocksDashboardDto
{
    public int Id { get; set; }

    public string Album { get; set; }

    public int AlbumId { get; set; }

    public decimal Price { get; set; }

    public string TypeOfRecord { get; set; }
}
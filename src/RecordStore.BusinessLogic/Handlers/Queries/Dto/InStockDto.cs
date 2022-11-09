using System;

namespace RecordStore.BusinessLogic.Dto;

public class InStockDto
{
    public int Id { get; set; }

    public string TypeOfRecord { get; set; }
    
    public int AlbumId { get; set; }
    
    public string Album { get; set; }

    public decimal Price { get; set; }
    
}
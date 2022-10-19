using RecordStore.DataAccess.Model.Base;

namespace RecordStore.DataAccess.Model
{
    public class Artist: Entity
    {
        
        public string Name { get; set; }
        
        public string Photo { get; set; }
        
        public string Bio { get; set; }
        
    }
}

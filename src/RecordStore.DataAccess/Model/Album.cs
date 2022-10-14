using System;
using System.Collections.Generic;
using RecordStore.DataAccess.Model.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordStore.DataAccess.Model
{
    public class Album: Base.Model
    {
  
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Artist { get; set; }
        public DateTime YearOfRelease { get; set; }
    }
}

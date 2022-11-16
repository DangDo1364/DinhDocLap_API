using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.GeoJSON
{
    public class GeoJSONFormat  
    {
        public string type { get; set; }
        public string generator { get; set; }
        public string copyright { get; set; }
        public string timestamp { get; set; }
        public List<Features> features { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.GeoJSON
{
 
    public class Geometry
    {
        public string type { get; set; }
        public List<List<double[]>> coordinates { get; set; }

    }
}

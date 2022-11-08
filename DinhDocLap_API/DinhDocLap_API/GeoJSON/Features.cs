using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.GeoJSON
{
    public class Features
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
}

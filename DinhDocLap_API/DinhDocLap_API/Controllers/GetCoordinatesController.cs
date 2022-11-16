using Azure;
using DinhDocLap_API.Data;
using DinhDocLap_API.GeoJSON;
using DinhDocLap_API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    public class GetCoordinatesController : ControllerBase
    {
        private readonly MyDBContext _context;
        public GetCoordinatesController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public string GetByID(int id)
        {
         
            List<Block> blocks = _context.blocks.Where(b=>b.IDBT==id).ToList();
            GeoJSONFormat geo = new GeoJSONFormat();

            geo.type = "FeatureCollection";
            geo.generator = "overpass-ide";
            geo.copyright = "The data included in this document is from www.openstreetmap.org. The data is made available under ODbL.";
            geo.timestamp = "2022-11-13T02:23:20Z";

            List<Features> listFeatures = new List<Features>();

            foreach(var b in blocks)
            {
                Features features = new Features();

                features.id = b.IDB.ToString();
                features.type = "Feature";

                Properties properties = new Properties();

                BlockType blockType = _context.blockTypes.ToArray().Where(b => b.IDBT == id).FirstOrDefault();
        
                properties.id = b.IDB.ToString();
                properties.blockName = blockType.blockName;
                properties.height = blockType.height;

                features.properties = properties;

                Geometry geometry = new Geometry();

                geometry.type = "Polygon";

                // get face
                int idFace = _context.blocks.Join(_context.faceBlocks,
                 b => b.IDB,
                 fb => fb.IDB,
                 (b, fb) => new
                 {
                     fb.IDF,
                     b.IDB,
                     b.IDBT,
                 }).Where(kq => kq.IDB == b.IDB).Select(kq => kq.IDF).FirstOrDefault();         

                var nodes = _context.nodes.Join(_context.faceNodes,
                  n => n.IDN,
                  fn => fn.IDN,
                  (n, fn) => new
                  {
                      fn.IDF,
                      n.x,
                      n.y,
                      n.z,
                      fn.seq,
                  }).Where(kq => kq.IDF == idFace).OrderBy(kq => kq.seq).ToArray();

                List<double[]> coordinates = new List<double[]>();

                foreach (var n in nodes)
                {
                    double[] node = new double[3] { (double)n.x, (double)n.y, (double)n.z };
                    coordinates.Add(node);
                }

                List<List<double[]>> listNode = new List<List<double[]>>();
                listNode.Add(coordinates);

                geometry.coordinates = listNode;
                features.geometry = geometry;


                //Add feature to list feature
                listFeatures.Add(features);
            }

            geo.features = listFeatures;
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(geo);

            return (jsonString);
        }
    }
}

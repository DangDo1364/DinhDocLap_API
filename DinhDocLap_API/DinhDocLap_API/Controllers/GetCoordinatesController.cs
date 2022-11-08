using DinhDocLap_API.Data;
using DinhDocLap_API.GeoJSON;
using DinhDocLap_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCoordinatesController : ControllerBase
    {
        private readonly MyDBContext _context;
        public GetCoordinatesController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllBlockType()
        {
            var listBlockType = _context.blockTypes.ToList();
            return Ok(listBlockType);
        }
        [HttpGet("{id}")]
        public string GetCoordinates(int id)
        {
            List<Block> blocks = _context.blocks.Where(b=>b.IDBT==id).ToList();
            GeoJSONFormat geo = new GeoJSONFormat();

            geo.type = "FeatureCollection";

            List<Features> listFeatures = new List<Features>();

            foreach(var b in blocks)
            {
                Features features = new Features();

                features.id = b.IDB.ToString();
                features.type = "Feature";

                BlockType blockType = _context.blockTypes.Where(b => b.IDBT == id).FirstOrDefault();

                if (blockType == null)
                    return "";

                Properties properties = new Properties();

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
            return jsonString;
        }
    }
}

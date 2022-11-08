using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class FaceBlock
    {

        [Display(Name = "Mã mặt phẳng")]
        public int IDF { get; set; }

        [Display(Name = "Mã khối")]
        public int IDB { get; set; }

        public Face face { get; set; }
        public Block block { get; set; }
    }
}

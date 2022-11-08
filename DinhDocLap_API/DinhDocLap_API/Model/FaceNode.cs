using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class FaceNode
    {
        [Display(Name = "Mã mặt phẳng")]
        public int IDF { get; set; }

        [Display(Name = "Mã node")]
        public int IDN { get; set; }

        [Display(Name = "Thứ tự")]
        public int seq { get; set; }

        public Face face { get; set; }
        public Node node { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class Face
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDF { get; set; }

        [Required]
        [Display(Name = "Tên mặt")]
        public string faceName { get; set; }
            
        public ICollection<FaceNode> faceNodes { get; set; }
        public ICollection<FaceBlock> faceBlocks { get; set; }

    }
}

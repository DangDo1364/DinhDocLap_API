using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class Block
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDB { get; set; }

        [Required]
        [Display(Name = "Mã loại khối")]
        public int IDBT { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string blockDesc { get; set; }

        [Required]
        [Display(Name = "Mã tòa nhà")]
        public int IDBD { get; set; }

        [ForeignKey("IDBD")]
        public Building building { get; set; }

        [ForeignKey("IDBT")]
        public BlockType blockType { get; set; }

        public ICollection<FaceBlock> faceBlocks { get; set; }
    }
}

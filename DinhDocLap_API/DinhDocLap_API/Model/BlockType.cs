using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class BlockType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDBT { get; set; }

        [Required]
        [Display(Name = "Tên chi tiết")]
        public string blockName { get; set; }

        [Required]
        [Display(Name = "Màu khối")]
        public string color { get; set; }

        [Required]
        [Display(Name = "Màu cạnh")]
        public string colorEdge { get; set; }

        [Required]
        [Display(Name = "Chiều cao")]
        public double height { get; set; }

        public ICollection<Block> blocks { get; set; }
    }
}

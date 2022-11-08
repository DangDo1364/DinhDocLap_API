using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLap_API.Model
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDBD { get; set; }

        [Required]
        [Display(Name = "Tên tòa nhà")]
        public string buildingName { get; set; }

        [Required]
        [Display(Name = "Địa chỉ tòa nhà")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string buildingDesc { get; set; }

        public ICollection<Block> blocks { get; set; }
    }
}

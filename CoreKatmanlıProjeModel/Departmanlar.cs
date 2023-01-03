using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanlıProjeModels
{
    public class Departmanlar
    {
        [Key]

        public int DepartmanId { get; set; }

        [Required]
        public string DepartmanAd { get; set; }

        [Required]
        public string ToplamCalisan { get; set; }

    }
}

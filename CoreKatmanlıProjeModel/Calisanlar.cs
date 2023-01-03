using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanlıProjeModels
{
    public class Calisanlar
    {
        [Key]
        public int CalisanId { get; set; }

        [Required]
        public string CalisanAd { get; set; }

        [Required]
        public int CalisanYas { get; set; }

        public int DepartmanId { get; set; }

        public string Fotograf { get; set; }

        public int Maas { get; set; }

        [ForeignKey("DepartmanId")]
        public Departmanlar Departmanlar { get; set; }
    }
}

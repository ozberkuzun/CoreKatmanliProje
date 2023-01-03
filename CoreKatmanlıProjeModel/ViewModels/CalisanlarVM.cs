using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreKatmanlıProjeModels.ViewModels
{
    public class CalisanlarVM
    {
        public Calisanlar Calisanlar { get; set; }
        public IEnumerable<SelectListItem> DepartmanlarList { get; set; }
    }
}

using CoreKatmanliProje.Data;
using CoreKatmanliProjeData.Repository.IRepository;
using CoreKatmanlıProjeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanliProjeData.Repository
{
    public class CalisanlarRepository : Repository<Calisanlar>, ICalisanlarRepository
    {
        private ApplicationDbContext _context;
        public CalisanlarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

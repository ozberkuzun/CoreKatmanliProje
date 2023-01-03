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
    public class DepartmanlarRepository : Repository<Departmanlar>, IDepartmanlarRepository
    {
        private ApplicationDbContext _context;
        public DepartmanlarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

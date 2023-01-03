using CoreKatmanliProje.Data;
using CoreKatmanliProjeData.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanliProjeData.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public IDepartmanlarRepository Departmanlar => new DepartmanlarRepository(_context);
        public ICalisanlarRepository Calisanlar => new CalisanlarRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

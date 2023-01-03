using CoreKatmanliProje.Data;
using CoreKatmanliProjeData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanliProjeData.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;  //sadece burada kullanmak ıstedıgım context sınıfımı okunabılır seklde ttanımaldım

        //yazdıgımız kodları daha kısa bır sekılde tanımalma yaparak kullanmak ıcın prohe ıcıde rahatlıkla cagırmak adına ınternal yapıuyoruz, ınternal olarak db set
        //olusturduk kalıtım olarak alan sınıflarda kolaylıklar erısebılırım.

        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)     //Dependency injection gerceklesmesi construcr olusturulu applicationcontextdb biligisini alıp burada dependency inejcsion aracılıgıyla bu islemi yapıyorum
                                                            //Db set kullanmamın sebebi ise get set islemleri yapmak icin pratik olarak cagırmak ıcın yaptık.
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}

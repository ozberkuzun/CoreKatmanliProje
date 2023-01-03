using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreKatmanliProjeData.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        //Tek bir sorgu satırı calıssın diye bunu yazıyoruz.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

        //sorug satırının bir liste halinde gelmesini sağlamak ıcın kullanbdık bu komut satırını //Getorfirst ve getall metotları
        //Direktt crud işlemlerinin read yani select secme getirme islemlerini  yapar, func dedigimiz aslında bizim action resultlarımızı
        //tanımlayan bir kod satırıdır, bu tanımları exprestionı kullanarak yaparız.

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        void RemoveRange(IEnumerable<T> entities);  //bunu yazmamızın sebebi ise eger id silersek herhangi bir tablodan diğer tablonun foreing olan alanların silinmesini otomatik                                          //olarak sağlması ıcın yazdık (sql deki cascade mantıgı)
    }
}

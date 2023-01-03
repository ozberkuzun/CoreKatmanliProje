using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreKatmanlıProjeModels;
using CoreKatmanliProje.Models;

namespace CoreKatmanliProjeData.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {

        IDepartmanlarRepository Departmanlar { get; }

        ICalisanlarRepository Calisanlar { get; }

        void Save();
    }
}

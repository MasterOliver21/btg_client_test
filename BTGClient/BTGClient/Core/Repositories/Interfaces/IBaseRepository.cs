using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTGClient.Core.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Update(T obj);
        void Insert(T obj);
        void Delete(T obj);
        T GetById(Guid id);
        List<T> GetAll();
        void DeleteAll();
    }
}

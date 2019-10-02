using ApiFvj.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFvj.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T listT);
        List<T> FindAll();
        T FindById(int Id);
        T Update(T item);
        void Delete(int Id);

        bool Exist(int Id);
    }
}

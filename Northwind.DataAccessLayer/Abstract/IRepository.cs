using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T:class,IEntity, new() //Bunu tüm ORM ler kullanabilir.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);       
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    


    }
}

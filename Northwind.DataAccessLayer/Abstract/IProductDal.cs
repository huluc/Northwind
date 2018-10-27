using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Abstract
{
    public interface IProductDal:IRepository<Product> //T nin bir class IEntity ve new lenebilir olması lazım.
    {
        //Product a özel bir metot yazmak istersek bu interface i kullanabiliriz.
        int GetProductAmount();
        /*
        List<Product> GetAll();
        Product Get(int id);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Delete(int id);
        */ //Normalde uzun uzun tüm metotlar bu şekilde yazıloıyordu fakat şimdi Repository Patttern sayesinde IRepositoryden implemente ettik.

    }
}

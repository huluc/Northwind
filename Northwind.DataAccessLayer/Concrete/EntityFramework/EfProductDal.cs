using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, NorthwindContextDB>, IProductDal//Bu katmanda sadece DB işlemleri CRUD yapıldı. Open Closed principle a göre kodumuz gelişime açık değişime kapalı olmalı. Mesela burada sql db yerine MySql kullanmak istesek kodu değiştirip ekleme yapmamız gerekir. Fakat Interface ile soyutlasak (sql için olan da Mysql için olan da aynı şeyi hedefliyor) kodu değiştirmemize gerek kalmaz.
    {
        public int GetProductAmount()
        {
            throw new NotImplementedException();
        }
    }
}

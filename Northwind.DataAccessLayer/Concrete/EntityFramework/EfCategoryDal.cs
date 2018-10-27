using Northwind.DataAccessLayer.Abstract;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework
{
   public class EfCategoryDal:EfRepositoryBase<Category,NorthwindContextDB>,ICategoryDal
        //EFRepositoryBase sayesinde CRUD işlemleri otomatik alındı. ICategoryDal sayesinde ise Category e özel metot var ise alındı.
    {
    }
}

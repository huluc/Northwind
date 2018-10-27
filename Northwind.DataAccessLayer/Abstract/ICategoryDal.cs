using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Northwind.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
      
    }
}

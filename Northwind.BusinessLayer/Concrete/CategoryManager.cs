using Northwind.BusinessLayer.Abstract;
using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Concrete
{
    //public class CategoryManager : ICategoryService
    //{
    //    private ICategoryDal _categoryDal;
    //    public CategoryManager(ICategoryDal categoryDal)
    //    {
    //        _categoryDal = categoryDal;       
    //    }
    //    public List<Category> GetAll()
    //    {
    //        return _categoryDal.GetAll();
    //    }

    //}
    //Singleton Design Pattern
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private static CategoryManager _categoryManager;
        static object _lockobject = new object();
        private CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public static CategoryManager CreateAsSingleton(ICategoryDal categoryDal)
        {
            lock (_lockobject)
            {
                if (_categoryManager == null)
                {
                    _categoryManager = new CategoryManager(categoryDal);
                }
            }

            return _categoryManager;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

    }
}

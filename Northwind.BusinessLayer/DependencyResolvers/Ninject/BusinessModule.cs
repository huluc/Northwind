using Ninject.Modules;
using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.Concrete;
using Northwind.DataAccessLayer.Abstract;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule//Container görevi görecek
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();//Daha sonra servis tabanlı bir mimariye geçtiğimizde değiştirmemiz gereken tek yer ProductMAnager olacak.
            //Değiştirmesek bile OracleBusinessModule, SqlBusinessModule gibi classlar oluşturabiliriz.
            Bind<IProductDal>().To<EfProductDal>();

        }
    }
}

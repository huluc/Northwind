using FluentValidation;
using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.Utilities;
using Northwind.BusinessLayer.ValidationRules.FluentValidation;
using Northwind.DataAccessLayer.Abstract;
using Northwind.DataAccessLayer.Concrete;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Concrete
{
    public class ProductManager: IProductService //Bir servis katmanı koyduğumuzda, o da IProductService'i implemente edecek. Yani ister servisli ister servissiz çalışabileceğiz.
    {
        private IProductDal _productDal; //İşte burada Dependency injection yapıyoruz. Ctor yoluyla. Burada artık istediğimiz ORM yi parametre olarak yollayabiliriz.
        //EfProductDal _productDal = new EfProductDal(); 
        //Yanlış kullanım!! Dependency (bağımlılık oluştu.) Open Closed principle a göre kodumuz gelişime açık değişime kapalı olmalı. Mesela burada sql db yerine MySql kullanmak istesek kodu değiştirip ekleme yapmamız gerekir. Fakat Interface ile soyutlasak (sql için olan da Mysql için olan da aynı şeyi hedefliyor) kodu değiştirmemize gerek kalmaz. Ayrıca Dependency Inversion a göre büyük modüller küçük modüllere bağlı olmamalı. Buradabüyük modül ProductManager işi bu yapıyor. Fakat burada EfProductDal a bağımlı. Yani ileride farklı bir db Mysql vs. kullanılırsa ProductManager değiştirlmek zorunda kalınacak. Yani küçük bir lamba yerine koca tesisat değişecek. Bu yüzden EfProductDal bu şekilde burada newlenmemelidir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(product);
            //if (result.Errors.Count > 0)
            //    throw new ValidationException(result.Errors);
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {          
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
           return _productDal.GetAll(x => x.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string text)
        {
            return _productDal.GetAll(x => x.ProductName.Contains(text));
        }
    }
}

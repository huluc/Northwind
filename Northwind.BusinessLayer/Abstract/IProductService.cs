using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Product> GetProductsByProductName(string text);
        void Add(Product product);
    }
}
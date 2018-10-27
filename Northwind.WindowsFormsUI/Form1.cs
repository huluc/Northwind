using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.Concrete;
using Northwind.BusinessLayer.DependencyResolvers.Ninject;
using Northwind.DataAccessLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Northwind.WindowsFormsUI
{
    public partial class txtProductNameAdd : Form
    {
        public txtProductNameAdd()
        {
            InitializeComponent(); 
        }
        IProductService _productService = InstanceFactory.GetInstance<IProductService>(); //IoC Container ile diyoruz ki bu instance akarşılık gelen somut sınıfı ver.
        //ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        ICategoryService _categoryService = CategoryManager.CreateAsSingleton(new EfCategoryDal());//Singleton Design Pattern kullanımı.Bu şekilde bir üretim ile instance ın sadece bir kez alındığını garantilemiş oluyoruz.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories(cbxCategories);
            LoadCategories(cbxCategory);
        }

        private void LoadCategories(ComboBox combobox)
        {
            combobox.DataSource = _categoryService.GetAll();
            combobox.DisplayMember = "CategoryName";
            combobox.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll();
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.GetProductsByCategoryId(Convert.ToInt32(cbxCategories.SelectedValue));
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productService.GetProductsByProductName(txtProductName.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(
          new Product
          {
              ProductName = txtProduct.Text,
              CategoryId = Convert.ToInt32(cbxCategory.SelectedValue),
              UnitPrice = Convert.ToDecimal(txtPrice.Text),
              UnitsInStock = Convert.ToInt16(txtUniıtInStock.Text),
              QuantityPerUnit = txtStock.Text
          });
                MessageBox.Show("İşlem Başarılı");
                LoadProducts();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
      


        }
    }
}

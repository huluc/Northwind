using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün Adı boş olamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(100).When(p => p.CategoryId == 2);

            RuleFor(p => p.ProductName).Must(startWithA).WithMessage("Ürün adı A ile başlamalı."); //Kendi validate miz.

        }

        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

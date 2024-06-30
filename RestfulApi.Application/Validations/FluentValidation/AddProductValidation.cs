using FluentValidation;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Validations.FluentValidation
{
    public class AddProductValidation:AbstractValidator<AddProductCommandRequest>
    {
        public AddProductValidation()
        {
            RuleFor(x => x.ProductPrice).GreaterThan(0).WithMessage("Ürün fiytı boş birakilamaz !.");
            RuleFor(x => x.ProductName).NotNull().WithMessage("Ürün adı boş birakilamaz !.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Ürün miktarı boş birakilamaz !.");
            RuleFor(x => x.DetailText).NotNull().WithMessage("Ürün detayı boş birakilamaz !.");
        }
    }
}

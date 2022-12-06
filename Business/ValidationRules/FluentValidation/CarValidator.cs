using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.BrandId).GreaterThan(0);
            RuleFor(p => p.ModelYear).GreaterThan(10).When(p => p.ModelYear == 1);
            RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Ürünler A harfıyla baslamalı");
            
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

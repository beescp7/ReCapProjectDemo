using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
           // RuleFor(p => p.CarId).Must(StartWithA).WithMessage("Ürünler A harfıyla baslamalı");

        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

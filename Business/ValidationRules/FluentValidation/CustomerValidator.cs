﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.CompanyName).Must(StartWithA).WithMessage("Ürünler A harfıyla baslamalı");

        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

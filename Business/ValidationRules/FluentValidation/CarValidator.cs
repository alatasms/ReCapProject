using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2); //kuraliçin
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(100);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(200).When(p => p.BrandId == 1);
            //RuleFor(p => p.CarName).Must(StartWithA);

        }

        //private bool StartWithA(string arg) //arg = CarName
        //{
        //    return arg.StartsWith("A");
        //}
    }
}

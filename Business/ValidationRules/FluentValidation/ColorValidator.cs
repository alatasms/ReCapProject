﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }

    }
}

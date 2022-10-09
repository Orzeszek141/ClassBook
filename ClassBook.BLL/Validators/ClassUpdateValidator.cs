﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.DTOs.Request;
using FluentValidation;

namespace ClassBook.BLL.Validators;

public class ClassUpdateValidator : AbstractValidator<ClassUpdateDto>
{
    public ClassUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.ClassNumber).Length(1, 5).WithMessage("Class number should have at least (1) character max to (5).").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Floor).GreaterThanOrEqualTo(-2).WithMessage("Given floor must be greater than (-3).").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.NumberOfComputers).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.FacultyId).NotEmpty().WithMessage("Should be not empty.");
    }
}
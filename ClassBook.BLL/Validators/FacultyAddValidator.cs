using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.DTOs.Request;
using FluentValidation;

namespace ClassBook.BLL.Validators;

public class FacultyAddValidator : AbstractValidator<FacultyAddDto>
{
    public FacultyAddValidator()
    {
        RuleFor(x => x.City).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.BuildingNb).Length(1, 5).WithMessage("Building number should have at least (1) character max to (5).").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.FacultyName).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.PostalCode).Length(6).WithMessage("Postal code should have (6) numbers").Matches("^[0-9]{2}-[0-9]{3}").WithMessage("Postal code should be in given format: 00-000").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Street).NotEmpty().WithMessage("Should be not empty.");
    }
}


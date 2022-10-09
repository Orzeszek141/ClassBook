using ClassBook.BLL.DTOs.Request;
using FluentValidation;

namespace ClassBook.BLL.Validators;

public class ClassAddValidator : AbstractValidator<ClassAddDto>
{
    public ClassAddValidator()
    {
        RuleFor(x => x.ClassNumber).Length(1,5).WithMessage("Class number should have at least (1) character max to (5).").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Floor).GreaterThanOrEqualTo(-2).WithMessage("Given floor must be greater than (-3).").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.NumberOfComputers).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.FacultyId).NotEmpty().WithMessage("Should be not empty.");
    }
}
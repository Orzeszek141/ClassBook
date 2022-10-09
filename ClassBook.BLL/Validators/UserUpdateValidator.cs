using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassBook.BLL.DTOs.Request;
using FluentValidation;

namespace ClassBook.BLL.Validators;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        var passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        RuleFor(x => x.Id).NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.FirstName).Matches("^[A-Z][a-z]*").WithMessage("First name should start with uppercase letter").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.LastName).Matches("^[A-Z][a-z]*").WithMessage("Last name should start with uppercase letter").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Should be email type").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password should have at least (8) chars").Matches(passwordRegex).WithMessage("Password should have at least one uppercase letter, one lowercase letter, one number and one special character").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.Role).IsInEnum().WithMessage("Should be of specified type").NotNull().WithMessage("Should be not empty.");
    }
}
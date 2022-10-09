using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassBook.BLL.DTOs.Request;
using FluentValidation;

namespace ClassBook.BLL.Validators;

public class UserInfoAddValidator : AbstractValidator<UserInfoAddDto>
{
    public UserInfoAddValidator()
    {
        var phoneNumberRegex = new Regex("^\\d+$");

        RuleFor(x => x.BirthDate).LessThan(new DateTime(2004,1,1)).WithMessage("Person had to be born earlier than year 2004").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.PhoneNumber).Length(9).WithMessage("Phone number should have 9 numbers").Matches(phoneNumberRegex).WithMessage("Phone number should contain only numbers").NotEmpty().WithMessage("Should be not empty.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Should be not empty.");
    }
}
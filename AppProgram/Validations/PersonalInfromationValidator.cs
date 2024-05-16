using AppProgram.Core;
using FluentValidation;

namespace AppProgram.Validations;
public class PersonalInfromationValidator : AbstractValidator<PersonalInformation>
{
    public PersonalInfromationValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Nationality).NotEmpty();
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.CurrentResidence).NotEmpty();
        RuleFor(x => x.IDNumber).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Now).WithMessage("Date of birth cannot be in the future");
        RuleFor(x => x.Gender).NotEmpty();
    }
}
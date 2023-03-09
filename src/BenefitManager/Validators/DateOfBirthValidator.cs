#region usings

using System.Reflection.Metadata;

using FluentValidation;

using PBM.Person;

#endregion

namespace PBM.Validators {
  public class DateOfBirthValidator : AbstractValidator<IPerson> {

    #region CTOR

    public DateOfBirthValidator() => RuleFor(p => p.DateOfBirth).Must(BePostPartum).Must(BeLessThanMaxAge);

    #endregion

    #region Validation Methods

    protected bool BePostPartum(DateOnly dob) => (dob <= Utils.TodaysDateOnly);

    protected bool BeLessThanMaxAge(DateOnly dob) => (Utils.TodaysDateOnly.Year - dob.Year) < Constants.MaxPersonAge;

    #endregion

  }
}

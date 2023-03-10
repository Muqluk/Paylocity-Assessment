using FluentValidation;

using PBM.Messages;
using PBM.Person;

namespace PBM.Validators {
  public class DateOfBirthValidator : AbstractValidator<IPerson> {
    private static DateOnly Today => Utils.TodaysDateOnly;

    public DateOfBirthValidator() => RuleFor(p => p.DateOfBirth)
      .Must(BePostPartum).WithMessage(ValidationError.MinAgeNotMet)
      .Must(BeLessThanOrEqualMaxAge).WithMessage(ValidationError.MaxAgeExceeded);

    protected static bool BePostPartum(DateOnly dateOfBirth) => Today >= dateOfBirth;

    protected static bool BeLessThanOrEqualMaxAge(DateOnly dateOfBirth) => (Today.Year - dateOfBirth.Year) <= Constants.MaxPersonAge;
  }
}

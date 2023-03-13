using FluentValidation;

using PBM.Validators;

namespace PBM.Person {
  public abstract class PersonBase : IPerson {
    #region Properties

    public virtual int Id { get; private set; }

    public virtual string FirstName { get; private set; }

    public virtual string LastName { get; private set; }

    public virtual DateOnly DateOfBirth { get; private set; }

    #endregion

    #region CTOR

    protected PersonBase(string firstName, string lastName, DateOnly dateOfBirth) {
      FirstName = firstName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
    }

    #endregion

    #region Virtual Methods

    public virtual void UpdateFirstName(string firstName) => FirstName = firstName.Trim();

    public virtual void UpdateLastName(string lastName) => LastName = lastName.Trim();

    public virtual void UpdateDateOfBirth(DateOnly dateOfBirth) => DateOfBirth = dateOfBirth;

    public virtual T SavePerson<T>() => throw new NotImplementedException();

    #endregion
  }

  public class PersonValidator : AbstractValidator<IPerson> {
    public PersonValidator() {
      RuleFor(x => x.FirstName).NotEmpty().Length(2, 30);
      RuleFor(x => x.LastName).NotEmpty().Length(2, 30);
      Include(new DateOfBirthValidator());
    }
  }
}

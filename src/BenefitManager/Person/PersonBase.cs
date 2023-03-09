#region usings 

using FluentValidation;

using PBM.Validators;

#endregion

namespace PBM.Person {
  public abstract class PersonBase : IPerson {

    #region Properties

    public virtual int Id { get; private set; }

    private string _fName = string.Empty;
    public virtual string FirstName {
      get => _fName;
      private set => _fName = value;
    }

    public virtual string LastName { get; private set; }

    private DateOnly _dob;
    public virtual DateOnly DateOfBirth {
      get => _dob;
      private set => _dob = value;
    }

    #endregion

    #region CTOR

    public PersonBase(string firstName, string lastName, DateOnly dateOfBirth, int personId = 0) {
      Id = personId;
      FirstName = firstName;
      LastName = lastName;
      DateOfBirth = dateOfBirth;
    }

    #endregion

    #region Virtual Methods

    public virtual void UpdateFirstName(string firstName) {
      FirstName = firstName.Trim();
    }

    public virtual void UpdateLastName(string lastName) {
      LastName = lastName;
    }

    public virtual void UpdateDateOfBirth(DateOnly dateOfBirth) {
      DateOfBirth = dateOfBirth;
    }

    public virtual T SavePerson<T>() {
      throw new NotImplementedException();
    }

    #endregion
  }

  public class PersonValidator : AbstractValidator<IPerson> {


    public PersonValidator() {

      When(x => !string.IsNullOrEmpty(x.FirstName), () => RuleFor(x => x.FirstName).NotEmpty().Length(2, 30));

      //RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
      //RuleFor(x => x.LastName).NotEmpty().Length(2, 30);
      Include(new DateOfBirthValidator());
    }
  }
}

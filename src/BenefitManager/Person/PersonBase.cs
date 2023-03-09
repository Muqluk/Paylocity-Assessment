namespace PBM.Person {
  public abstract class PersonBase : IPerson {

    #region Properties

    public virtual int Id { get; private set; } = 0;

    public virtual string FirstName { get; private set; } = "";

    public virtual string LastName { get; private set; } = "";

    public virtual DateOnly DateOfBirth { get; private set; }

    #endregion

    #region CTOR

    public PersonBase(string firstName, string lastName, DateOnly dateOfBirth) {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.DateOfBirth = dateOfBirth;
    }

    #endregion

    #region Virtual Methods

    public virtual void UpdateFirstName(string firstName) {
      FirstName = firstName;
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
}

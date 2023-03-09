namespace PBM.Person {
  public interface IPerson {

    #region Properties

    int Id { get; }

    string FirstName { get; }

    string LastName { get; }

    DateOnly DateOfBirth { get; }

    #endregion

    #region Methods

    void UpdateFirstName(string firstName);

    void UpdateLastName(string lastName);

    void UpdateDateOfBirth(DateOnly dateOfBirth);

    T SavePerson<T>();

    #endregion
  }
}

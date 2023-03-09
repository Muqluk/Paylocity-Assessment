namespace PBM.Person {
  public class Employee : PersonBase, IEmployee {

    #region Properties

    public int EmployeeId { get; } = 0;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public IList<IDependent> Dependents { get; set; } = new List<IDependent>();

    #endregion

    #region CTOR

    public Employee(string firstName, string lastName, DateOnly dateOfBirth)
      : base(firstName, lastName, dateOfBirth) { }

    #endregion

    #region Methods

    public void AddDependent(IDependent dependent) {
      throw new NotImplementedException();
    }

    public void RemoveDependent(IDependent dependent) {
      throw new NotImplementedException();
    }

    public void UpdateDependent(IDependent dependent) {
      throw new NotImplementedException();
    }


    #endregion
  }
}

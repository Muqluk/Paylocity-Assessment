namespace PBM.Person {
  public interface IEmployee : IPerson {

    #region Properties

    int EmployeeId { get; }

    DateOnly StartDate { get; set; }

    DateOnly EndDate { get; set; }

    IList<IDependent> Dependents { get; set; }

    #endregion

    #region Methods

    void AddDependent(IDependent dependent);

    void RemoveDependent(IDependent dependent);

    void UpdateDependent(IDependent dependent);

    #endregion

  }
}

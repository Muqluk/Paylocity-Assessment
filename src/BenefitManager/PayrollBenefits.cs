using PBM.Person;

namespace PBM {
  public class PayrollBenefits {

    private IList<IPerson> Persons { get; set; } = new List<IPerson>();

    public IList<IAdministrator> AllAdministrators {
      get => GetPeopleOfType<IAdministrator>();
    }

    public IList<IEmployee> AllEmployees {
      get => GetPeopleOfType<IEmployee>();
    }

    public IList<IDependent> AllDependents {
      get => GetPeopleOfType<IDependent>();
    }

    private IList<T> GetPeopleOfType<T>() where T : class, IPerson
      => Persons.Where(p => p is T).Select(p => p as T).ToList();

    public IList<IDependent> GetDependentsOf(IEmployee employee) =>
      AllDependents.Where(d => d.DependentEmployeeId == employee.Id).ToList();

    public void AddEmployee(IEmployee person) => Persons.Add(person);

    public void RemoveEmployee(IEmployee person) => Persons.Remove(person);

    public IEmployee FindEmployeeById(int id) => AllEmployees.Single(p => p.EmployeeId == id);

    public IDependent FindDependentById(int id) => AllDependents.Single(d => d.DependentEmployeeId == id);

    public void UpdateEmployee(IEmployee employee) => throw new NotImplementedException();

    public void PromoteAdministrator(IEmployee person) => throw new NotImplementedException();

    public void DemoteAdministrator(IAdministrator person) => throw new NotImplementedException();
  }
}

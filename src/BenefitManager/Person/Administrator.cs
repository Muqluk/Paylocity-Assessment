using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBM.Person {
  public class Administrator : IAdministrator {
    #region IEmployee Properties

    public int EmployeeId { get; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public IList<IDependent> Dependents { get; set; }
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly DateOfBirth { get; }

    #endregion

    #region IEmployee Methods

    public void AddDependent(IDependent dependent) {
      throw new NotImplementedException();
    }

    public void RemoveDependent(IDependent dependent) {
      throw new NotImplementedException();
    }

    public T SavePerson<T>() {
      throw new NotImplementedException();
    }

    public void UpdateDateOfBirth(DateOnly dateOfBirth) {
      throw new NotImplementedException();
    }

    public void UpdateDependent(IDependent dependent) {
      throw new NotImplementedException();
    }

    public void UpdateFirstName(string firstName) {
      throw new NotImplementedException();
    }

    public void UpdateLastName(string lastName) {
      throw new NotImplementedException();
    }

    #endregion

    public void ReviewPrePayrollReport() => throw new NotImplementedException();
  }
}

#region usings

using FluentValidation;
using FluentValidation.TestHelper;

using PBM.Person;
using PBM.Validators;

#endregion

namespace PBM.Tests.Validators {

  #region AccountBase Implementation Fixture

  public class PersonBaseMock : PersonBase {

    public PersonBaseMock(string firstName, string lastName, DateOnly dateOfBirth)
      : base(firstName, lastName, dateOfBirth) { }
  }

  #endregion


  [TestClass]
  public class DateOfBirthValidator_Tests {

    #region Setup and Teardown

    private IPerson? person;
    private DateOfBirthValidator? validator;
    private DateOnly dateToday = Utils.TodaysDateOnly;

    [TestInitialize]
    public void Init() {
      validator = new DateOfBirthValidator();

    }

    [TestCleanup]
    public void Cleanup() {
      validator = null;
      person = null;
    }

    #endregion

    [TestMethod]
    public void DateOfBirthValidator_throws_error_when_DoB_is_greater_than_todays_date_plus_1_day() {
      var result = validator.TestValidate(new PersonBaseMock("Mickey", "Mouse", dateToday.AddDays(1)));

      result.ShouldHaveValidationErrorFor(person => person.DateOfBirth);
    }

    [TestMethod]
    public void DateOfBirthValidator_no_error_thrown_throws_error_when_DoB_is_less_than_or_equal_to_today() {
      var result = validator.TestValidate(new PersonBaseMock("Mickey", "Mouse", dateToday));

      result.ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);
    }

    [TestMethod]
    public void DateOfBirthValidator_throws_error_when_DoB_is_more_than_ConstantsMaxPersonAge_years_ago() {
      var dateToday = Utils.TodaysDateOnly;

      var result = validator.TestValidate(new PersonBaseMock("Mickey", "Mouse", dateToday.AddYears(-Constants.MaxPersonAge)));

      result.ShouldHaveValidationErrorFor(person => person.DateOfBirth);
    }

    [TestMethod]
    public void DateOfBirthValidator_no_error_thrown_throws_error_when_DoB_is_between_today_and_Constants_MaxPersonAge() {
      var dateToday = Utils.TodaysDateOnly;

      var result = validator.TestValidate(new PersonBaseMock("Mickey", "Mouse", dateToday.AddYears(-Constants.MaxPersonAge).AddDays(1)));

      result.ShouldHaveValidationErrorFor(person => person.DateOfBirth);
    }

  }
}

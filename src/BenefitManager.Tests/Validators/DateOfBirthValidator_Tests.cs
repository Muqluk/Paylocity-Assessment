using PBM.Person;
using PBM.Validators;

namespace PBM.Tests.Validators {

  #region AccountBase Mock

  public class PersonBaseMock : PersonBase {
    public PersonBaseMock(string firstName, string lastName, DateOnly dateOfBirth)
      : base(firstName, lastName, dateOfBirth) { }

    public static PersonBaseMock GetPersonMock(DateOnly dateOfBirth) => new("Mickey", "Mouse", dateOfBirth);
  }

  #endregion

  [TestClass]
  public class DateOfBirthValidator_Tests {

    #region Setup and Teardown

    private static DateOnly DateToday => Utils.TodaysDateOnly;
    private DateOfBirthValidator? validator;
    private readonly int maxAge = Constants.MaxPersonAge * -1;

    private static DateOnly DobPlusDays(int plusDays = 0) => DateToday.AddDays(plusDays);
    private static DateOnly DobPlusYears(int plusYears = 0) => DateToday.AddYears(plusYears);

    [TestInitialize]
    public void Init() => validator = new DateOfBirthValidator();

    #endregion

    [TestMethod]
    public void Throws_error_when_DoB_is_greater_than_todays_date() =>
      validator.TestValidate(PersonBaseMock.GetPersonMock(DobPlusDays(1)))
        .ShouldHaveValidationErrorFor(person => person.DateOfBirth);

    [TestMethod]
    public void No_error_thrown_when_DoB_is_less_than_or_equal_to_today() =>
      validator.TestValidate(PersonBaseMock.GetPersonMock(DateToday))
        .ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);

    [TestMethod]
    public void Throws_error_when_DoB_is_greater_than_maxAge() =>
      validator.TestValidate(PersonBaseMock.GetPersonMock(DobPlusYears(maxAge - 1)))
        .ShouldHaveValidationErrorFor(person => person.DateOfBirth);

    [TestMethod]
    public void No_error_thrown_when_DoB_is_between_today_and_maxAge() =>
      validator.TestValidate(PersonBaseMock.GetPersonMock(DateToday.AddYears(maxAge)))
      .ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);
  }
}

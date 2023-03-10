using PBM.Person;

namespace PBM.Tests.Person {
  #region AccountBase Implementation Fixture

  public class PersonBaseMock : PersonBase {
    public PersonBaseMock(string firstName, string lastName, DateOnly dateOfBirth)
      : base(firstName, lastName, dateOfBirth) { }
  }

  #endregion

  [TestClass]
  public class PersonBase_Tests {
    #region Setup

    private readonly DateOnly today = Utils.TodaysDateOnly;
    private PersonBaseMock person = new("Mickey", "Mouse", DateOnly.Parse("10/06/1975"));
    private PersonValidator personValidator = new();

    [TestInitialize]
    public void Init() {
      personValidator = new PersonValidator();
      person = new("Mickey", "Mouse", DateOnly.Parse("10/06/1975"));
    }

    #endregion

    #region Property Validation Integration Tests

    [TestMethod]
    public void Updating_FirstName_property_throws_error_when_less_than_2_non_whitespace_characters() {

      person.UpdateFirstName("");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.FirstName);

      person.UpdateFirstName(" ");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.FirstName);

      person.UpdateFirstName("S");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.FirstName);

      person.UpdateFirstName("SA");
      personValidator.TestValidate(person).ShouldNotHaveValidationErrorFor(person => person.FirstName);
    }

    [TestMethod]
    public void Updating_LastName_property_throws_error_when_less_than_2_non_whitespace_characters() {

      person.UpdateLastName("");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.LastName);

      person.UpdateLastName(" ");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.LastName);

      person.UpdateLastName("S");
      personValidator.TestValidate(person).ShouldHaveValidationErrorFor(person => person.LastName);

      person.UpdateLastName("SA");
      personValidator.TestValidate(person).ShouldNotHaveValidationErrorFor(person => person.LastName);
    }

    [TestMethod]
    public void Updating_DateOfBirth_property_throws_error_if_born_on_a_future_date() {
      person.UpdateDateOfBirth(today.AddDays(1));
      personValidator.TestValidate(person)
        .ShouldHaveValidationErrorFor(person => person.DateOfBirth)
        .WithErrorMessage(PBM.Messages.ValidationError.MinAgeNotMet);
    }

    [TestMethod]
    public void Updating_DateOfBirth_property_does_not_error_if_born_at_any_time_today() {
      person.UpdateDateOfBirth(today);
      personValidator.TestValidate(person)
        .ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);
    }

    [TestMethod]
    public void Updating_DateOfBirth_property_does_not_error_if_born_exactly_MaxPersonAge_years_ago() {
      person.UpdateDateOfBirth(today.AddYears(Constants.MaxPersonAge * -1));
      personValidator.TestValidate(person)
        .ShouldNotHaveValidationErrorFor(person => person.DateOfBirth);
    }

    [TestMethod]
    public void Updating_DateOfBirth_property_throws_error_if_born_at_any_time_exceeding_MaxPersonAge() {
      person.UpdateDateOfBirth(today.AddYears((Constants.MaxPersonAge * -1) - 1));
      personValidator.TestValidate(person)
        .ShouldHaveValidationErrorFor(person => person.DateOfBirth)
        .WithErrorMessage(PBM.Messages.ValidationError.MaxAgeExceeded);
    }

    #endregion

    #region Methods

    [TestMethod]
    public void UpdateFirstName_sets_FirstName_property() {
      var expected = "Minnie";
      Assert.AreEqual("Mickey", person.FirstName);

      person.UpdateFirstName(expected);
      Assert.AreEqual(expected, person.FirstName);
    }

    [TestMethod]
    public void UpdateLastName_sets_LastName_property() {
      var expected = "Mantle";
      Assert.AreEqual("Mouse", person.LastName);

      person.UpdateLastName(expected);
      Assert.AreEqual(expected, person.LastName);
    }

    [TestMethod]
    public void DateOfBirth() {
      var expected = DateOnly.Parse("10/10/2012");
      Assert.AreEqual(DateOnly.Parse("10/06/1975"), person.DateOfBirth);

      person.UpdateDateOfBirth(expected);
      Assert.AreEqual(expected, person.DateOfBirth);
    }

    #endregion
  }
}

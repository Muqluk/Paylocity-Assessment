using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    #region Setup and Teardown

    IPerson? person;

    [TestInitialize]
    public void Init() {
      person = new PersonBaseMock("Mickey", "Mouse", DateOnly.Parse("10/06/1975"));
    }

    [TestCleanup]
    public void Cleanup() {
      person = null;
    }

    #endregion

    #region Property Validation Tests

    [TestMethod]
    public void updating_FirstName_property_throws_error_when_less_than_2_non_whitespace_characters() {
      person?.UpdateFirstName("");
      //Assert.Fail();
    }

    [TestMethod]
    public void updating_DateOfBirth_property_throws_error_when_dob_provided_is_after_today() {
      person?.UpdateDateOfBirth(Utils.TodaysDateOnly.AddDays(1));
      //Assert.Fail();
    }

    #endregion

    #region Constructor Tests

    [TestMethod]
    public void PersonBase_can_be_instantiated() {
      Assert.IsInstanceOfType(person, typeof(PersonBase));
    }

    #endregion

    #region Methods

    [TestMethod]
    public void UpdateFirstName_sets_FirstName_property() {
      var expected = "Minnie";
      Assert.AreEqual("Mickey", person?.FirstName);

      person?.UpdateFirstName(expected);
      Assert.AreEqual(expected, person?.FirstName);
    }

    [TestMethod]
    public void UpdateLastName_sets_LastName_property() {
      var expected = "Mantle";
      Assert.AreEqual("Mouse", person?.LastName);

      person?.UpdateLastName(expected);
      Assert.AreEqual(expected, person?.LastName);
    }

    [TestMethod]
    public void DateOfBirth() {
      var expected = DateOnly.Parse("10/10/2012");
      Assert.AreEqual(DateOnly.Parse("10/06/1975"), person?.DateOfBirth);

      person?.UpdateDateOfBirth(expected);
      Assert.AreEqual(expected, person?.DateOfBirth);
    }

    #endregion

  }
}

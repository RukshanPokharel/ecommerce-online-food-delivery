using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverApplication.Tests
{
    public class DataAccessTests
    {
        //[Fact]
        //public void AddPersonToPeopleList_ShouldWork()
        //{
        //    PersonModel newPerson = new PersonModel{ firstname = "tim", lastname= "corey"};
        //    List<PersonModel> people = new List<PersonModel>();

        //    people.Add(newPerson); // actual test of the method that you want for this test..
            
        //    Assert.True(people.Count == 1);
        //    Assert.Contains<PersonModel>(newPerson , people);
        //}

        //// in case the above test fails
        //[Theory]
        //[InlineData("Tim", "", "LastName")]
        //[InlineData("", "Corey", "FirstName")]
        //public void AddPersonToPeopleList_ShouldFail(string firstname, string lastname, string param)
        //{
        //    PersonModel newPerson = new PersonModel{ firstname = firstname , lastname= lastname};
        //    List<PersonModel> people = new List<PersonModel>();

        //    Assert.Throws<ArgumentException>(param, () => people.Add(newPerson));
        //}

        //private class PersonModel
        //{
        //    internal string firstname;
        //    internal string lastname;
        //}
    }
}

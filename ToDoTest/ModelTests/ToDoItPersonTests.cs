using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Model;
using Xunit;

namespace ToDoTest
{
    public class ToDoItPersonTests
    {
		private Person personToTest;

		public ToDoItPersonTests()
		{
			personToTest = new(1);
			personToTest.FirstName = "firstName";
			personToTest.LastName = "lastName";
		}
        [Fact]
        public void SetLastNameNullTest()
        {
            Assert.Throws<ArgumentException>(() => personToTest.LastName = null);
        }

        [Fact]
        public void SetFirstNameNullTest()
        {
            Assert.Throws<ArgumentException>(() => personToTest.FirstName = null);
        }

        [Fact]
        public void SetLastNameEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => personToTest.LastName = String.Empty);
        }

        [Fact]
        public void SetFirstNameEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => personToTest.FirstName = String.Empty);
        }

        [Fact]
        public void GetIdTest()
        {
            int personId = personToTest.PersonId;
            int expectedPersonId = 1;

            Assert.Equal(expectedPersonId, personId);
        }

        [Fact]
        public void GetFirstNameTest()
        {
            String firstName = personToTest.FirstName;
            String expectedFirstName = "firstName";

            Assert.Equal(expectedFirstName, firstName);
        }

        [Fact]
        public void GetLastNameTest()
        {
            String lastName = personToTest.LastName;
            String expectedLastName = "lastName";

            Assert.Equal(expectedLastName, lastName);
        }

        [Fact]
        public void SetFirstNameTest()
        {
            personToTest.FirstName = "newFirstName";
            String expectedFirstName = "newFirstName";

            Assert.Equal(expectedFirstName, personToTest.FirstName);
        }

        [Fact]
        public void SetLastNameTest()
        {
            personToTest.LastName = "newLastName";
            String expectedLastName = "newLastName";

            Assert.Equal(expectedLastName, personToTest.LastName);
        }
    }
}

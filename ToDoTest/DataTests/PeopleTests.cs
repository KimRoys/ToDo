using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Data;
using ToDo_App.Model;
using Xunit;

namespace ToDoTest.DataTests
{
    public class PeopleTests
    {
        private People people;

        public PeopleTests()
        {
            PersonSequencer.reset();
            people = new People();
            people.Clear();
        }

        [Fact]
        public void ClearPeople()
        {
            PersonSequencer.reset();
           people.Clear();
        }

        [Fact]
        public void AddTest()
        {
            people.Add("firstNameOne", "lastNameOne");
            people.Add("firstNameTwo", "lastNameTwo");
            Person personThree = people.Add("firstNameThree", "lastNameThree");

            Assert.Equal(3, personThree.PersonId);
            Assert.Equal(3, people.Size());
        }

        [Fact]
        public void AddEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => people.Add(string.Empty, "firstname"));
            Assert.Throws<ArgumentException>(() => people.Add(string.Empty, "lastName"));
        }

        [Fact]
        public void AddNullTest()
        {
            Assert.Throws<ArgumentException>(() => people.Add(null, "firstname"));
            Assert.Throws<ArgumentException>(() => people.Add(null, "lastName"));
        }

        [Fact]
        public void FindAllPersonsTest()
        {
            people.Add("Janne", "Långben");
            people.Add("Musse", "Pigg");
            people.Add("Kalle", "Anka");
            people.Add("Kajsa", "Anka");

            Person[] allPersons = people.FindAll();

            Assert.True(allPersons.Length == 4);
            Assert.Equal(2, allPersons[1].PersonId);
            Assert.Equal(4, allPersons[3].PersonId);
        }


        [Fact]
        public void FindByIdTest()
        {
            people.Add("Janne", "Långben");
            people.Add("Musse", "Pigg");

            Person person = people.FindById(2);
            Assert.Equal("Musse", person.FirstName);
        }

        [Fact]
        public void FindByIdNullTest()
        {
            people.Clear();
            people.Add("Janne", "Långben");
            people.Add("Musse", "Pigg");

            Person person = people.FindById(9);
            Assert.Null(person);
        }

        [Fact]
        public void ClearTest()
        {
            people.Add("Janne", "Långben");
            people.Add("Musse", "Pigg");

            Assert.Equal(2, people.Size());
            people.Clear();
            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void RemoveTest()
        {
            people.Add("Janne", "Långben");
            people.Add("Musse", "Pigg");
            people.Add("Kalle", "Anka");
            people.Add("Kajsa", "Anka");

            Person[] allPersons = people.FindAll();
            
            Assert.True(allPersons.Length == 4);
            people.Remove(2);

            allPersons = people.FindAll();

            Assert.True(allPersons.Length == 3);
            Assert.Equal(1, allPersons[0].PersonId);
            Assert.Equal(4, allPersons[2].PersonId);
        }

    }
}

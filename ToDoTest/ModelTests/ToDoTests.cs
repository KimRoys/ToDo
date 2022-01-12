using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Model;
using Xunit;

namespace ToDoTest.ModelTests
{
    public class ToDoTests
    {
        private ToDo toDoTest;

        public ToDoTests()
        {
            toDoTest = new(1);
            toDoTest.Description = "description";
            toDoTest.Done = false;
            toDoTest.Assignee = new(1);
            toDoTest.Assignee.FirstName = "firstname";
            toDoTest.Assignee.LastName = "lastname";            
        }

        [Fact]
        public void GetIdTest()
        {
            int toDoId = toDoTest.ToDoId;
            int expected = 1;
            Assert.Equal(expected, toDoId);
        }

        [Fact]
        public void GetDescription()
        {
            string description = toDoTest.Description;
            string expected = "description";

            Assert.Equal(expected, description);
        } 

        [Fact]
        public void GetDone()
        {
            bool done = toDoTest.Done;
            bool expected = false;

            Assert.Equal(expected, done);
        }

        [Fact]
        public void SetDone()
        {
            toDoTest.Done = true;

            Assert.True(toDoTest.Done);
        }

        [Fact]
        public void GetPerson()
        {
            Person person = toDoTest.Assignee;
            int expected = 1;

            Assert.Equal(expected, person.PersonId);
        }

        [Fact]
        public void SetPerson()
        {
            toDoTest.Assignee = new(2);

            Assert.Equal(2, toDoTest.Assignee.PersonId);
        }

    }
}

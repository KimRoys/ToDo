using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Data;
using Xunit;

namespace ToDoTest.DataTests
{
    public class PersonSequencerTests
    {
        public PersonSequencerTests()
        {
            PersonSequencer.reset();
        }

        [Fact]
        public void NextPersonIdTest()
        {
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            int personId = PersonSequencer.nextPersonId();

            Assert.Equal(3, personId);
        }

        [Fact]
        public void ResetTest()
        {
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.reset();

            Assert.Equal(1, PersonSequencer.nextPersonId());
        }
    }
}

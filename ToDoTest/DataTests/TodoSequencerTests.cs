using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Data;
using Xunit;

namespace ToDoTest.DataTests
{
    public class TodoSequencerTests
    {
        public TodoSequencerTests()
        {
            TodoSequencer.reset();
        }

        [Fact]
        public void NextToDoIdTest()
        {
            TodoSequencer.nextToDoId();
            TodoSequencer.nextToDoId();
            int toDoId = TodoSequencer.nextToDoId();

            Assert.Equal(3, toDoId);
        }

        [Fact]
        public void ResetTest()
        {
            TodoSequencer.nextToDoId();
            TodoSequencer.nextToDoId();
            TodoSequencer.reset();

            Assert.Equal(1, TodoSequencer.nextToDoId());
        }
    }
}

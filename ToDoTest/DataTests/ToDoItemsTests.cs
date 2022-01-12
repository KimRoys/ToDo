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
    public class ToDoItemsTests
    {
        private ToDoItems toDoItems;

        public ToDoItemsTests()
        {
            toDoItems = new ToDoItems();
            TodoSequencer.reset();
            toDoItems.Clear();        }

        [Fact]
        public void ClearToDoItems()
        {
            TodoSequencer.reset();
            toDoItems.Clear();
        }

        [Fact]
        public void AddToDoItemsTest()
        {
            toDoItems.Add("descriptionOne", false);
            toDoItems.Add("descriptionTwo", false);
            toDoItems.Add("descriptionThree", false);
            ToDo toDoItemFour = toDoItems.Add("descriptionFour", false);

            Assert.Equal(4, toDoItemFour.ToDoId);
            Assert.Equal(4, toDoItems.Size());
        }

        [Fact]
        public void FindByDoneStatusTest()
        {
            toDoItems.Add("Description 1", true);
            toDoItems.Add("Description 2", false);
            toDoItems.Add("Description 3", true);
            toDoItems.Add("Description 4", false);
            toDoItems.Add("Description 5", true);

            ToDo[] toDos = toDoItems.FindByDoneStatus(true);

            Assert.True(toDos.Length == 3);
            Assert.Equal(3, toDos[1].ToDoId);
        }

        [Fact]
        public void FindByAssigneeTest()
        {
            ToDoItems toDoItems = new ToDoItems();
            Person personToTest = new Person();

            Assert.NotNull(toDoItems);
            Assert.NotNull(personToTest);

            toDoItems.Add("Test", false);
            toDoItems.Add("TestTwo", true, personToTest);
            toDoItems.Add("TestThree", true);
            toDoItems.Add("TestFour", false);

            ToDo[] toDoItemsArr = toDoItems.FindByAssignee(personToTest);

            Assert.NotNull(toDoItemsArr);

            foreach (var item in toDoItemsArr)
            {
                Assert.Equal(personToTest, item.Assignee);
            }
        }

        [Fact]
        public void FindUnassignedTodoItemsTest()
        {
            Person personToTest = new Person(1);
            ToDo toDonum1 = toDoItems.Add("description1", false);
            toDonum1.Assignee = personToTest;
            ToDo toDoNum2 = toDoItems.Add("description2", false);
            toDoNum2.Assignee = personToTest;
            toDoItems.Add("description3", false, personToTest);
            toDoItems.Add("description4", true);
            toDoItems.Add("description5", false);

            ToDo[] toDoItemsArr = toDoItems.FindUnassignedTodoItems();

            Assert.True(toDoItemsArr.Length == 2);
            Assert.Equal(5, toDoItemsArr[1].ToDoId);
        }

        [Fact]
        public void RemoveTest()
        {
            toDoItems.Add("description1", false);
            toDoItems.Add("description2", false);
            toDoItems.Add("description3", false);
            toDoItems.Add("description4", false);

            toDoItems.Remove(3);

            ToDo[] toDoAll = toDoItems.FindAll();

            Assert.True(toDoAll.Length == 3);

            Assert.Equal(1, toDoAll[0].ToDoId);
            Assert.Equal(2, toDoAll[1].ToDoId);
            Assert.Equal(4, toDoAll[2].ToDoId);
        }

        [Fact]
        public void RemoveTestIdNotFound()
        {
            toDoItems.Add("description1", false);
            toDoItems.Add("description2", false);
            toDoItems.Add("description3", false);
            toDoItems.Add("description4", false);

            toDoItems.Remove(9);

            ToDo[] toDoAll = toDoItems.FindAll();

            Assert.True(toDoAll.Length == 4);
        }

    }
}

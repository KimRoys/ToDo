using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Model;

namespace ToDo_App.Data
{
    public class ToDoItems
    {
        private static ToDo[] toDoArr = new ToDo[0];

        public int Size()
        {
            return toDoArr.Length;
        }

        public ToDo[] FindAll()
        {
            return toDoArr;
        }

        public ToDo FindById(int todoId)
        {
            foreach (ToDo toDoItem in toDoArr)
            {
                if (toDoItem.ToDoId == todoId)
                {
                    return toDoItem;
                }
            }
            return null;
        }

        public ToDo Add(string description, bool done)
        {
            ToDo[] tmpArray = toDoArr;
            int newLength = toDoArr.Length + 1;
            toDoArr = new ToDo[newLength];

            if (toDoArr.Length > 1)
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    toDoArr[i] = tmpArray[i];
                }
            toDoArr[newLength - 1] = CreateToDo(description, done);
            return toDoArr[newLength - 1];
        }

        public ToDo Add(string description, bool done, Person assignee = null)
        {
            ToDo[] newTodoitemsArr;
            ToDo todoItem;

            int index = Size();                                      
            int newcount = index + 1;
            int todoID = TodoSequencer.nextToDoId();             

            todoItem = new ToDo(todoID, description);                  
            todoItem.Done = done;
            todoItem.Assignee = assignee;

            newTodoitemsArr = new ToDo[newcount];          

            toDoArr.CopyTo(newTodoitemsArr, 0);         
            newTodoitemsArr[index] = todoItem;              

            toDoArr = newTodoitemsArr;              

            return todoItem;
        }

        public ToDo CreateToDo(string description, bool done)
        {
            int toDoId = TodoSequencer.nextToDoId();
            ToDo toDo = new(toDoId);
            toDo.Description = description;
            toDo.Done = done;
            return toDo;
        }

        public void Clear()
        {
            toDoArr = Array.Empty<ToDo>();
        }

        public ToDo[] FindByDoneStatus(bool done)
        {
            ToDo[] sortedArr = new ToDo[0];
            foreach (ToDo toDo in toDoArr)
            {
                if (toDo.Done == done)
                {
                    Array.Resize(ref sortedArr, sortedArr.Length + 1);
                    sortedArr[sortedArr.Length - 1] = toDo;
                }
            }
            return sortedArr;
        }

        public ToDo[] FindByAssignee(int personId)
        {
            ToDo[] sortedArr = new ToDo[0];
            foreach (ToDo todo in toDoArr)
            {
                if (todo.Assignee != null && todo.Assignee.PersonId == personId)
                {
                    Array.Resize(ref sortedArr, sortedArr.Length + 1);
                    sortedArr[sortedArr.Length - 1] = todo;
                }
            }
            return sortedArr;
        }

        public ToDo[] FindByAssignee(Person assignee)
        {
            ToDo[] sortedArr = new ToDo[0];
            foreach (var item in toDoArr)
            {
                if (item.Assignee  == assignee)
                {
                    Array.Resize(ref sortedArr, sortedArr.Length + 1);
                    sortedArr[sortedArr.Length - 1] = item;
                }
            }
            return sortedArr;
        }

        public ToDo[] FindUnassignedTodoItems()
        {            
            ToDo[] sortedArr = new ToDo[0];
            foreach (var item in toDoArr)
            {
                if (null == item.Assignee)
                {
                    Array.Resize(ref sortedArr, sortedArr.Length + 1);
                    sortedArr[sortedArr.Length - 1] = item;
                }
            }
            return sortedArr;
        }
    }
}

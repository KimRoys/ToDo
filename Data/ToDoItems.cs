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
    }
}

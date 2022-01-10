using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App.Model
{
    public class ToDo
    {
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public ToDo(int todoId)
        {
            this.todoId = todoId;
        }

        public int ToDoId
        {
            get => todoId;
        }

        public ToDo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public bool Done
        {
            get => done;
            set => done = value;
        }

        public Person Person
        {
            get => assignee;
            set => assignee = value;
        }
    }
}

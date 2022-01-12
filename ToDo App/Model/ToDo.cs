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

        public int ToDoId => todoId;
        public ToDo(int todoId)
        {
            this.todoId = todoId;
        }


        public ToDo(int todoId, string description) : this()
        {
            this.todoId = todoId;
            this.description = description;
        }

        public string Description
        {
            get => description;
            set
            {
                if (value == null)              // Check for null assignment
                {
                    throw new ArgumentNullException("Description", "property Description cannot be assigned a null value!");
                }

                description = value;
            }
        }

        public bool Done
        {
            get => done;
            set => done = value;
        }

        public Person Assignee 
        { 
            get => assignee; 
            set => assignee = value; 
        
        }

        public ToDo()
        {
            assignee = null;
            done = false;
            todoId = 0;
            description = "";
        }
    }
}

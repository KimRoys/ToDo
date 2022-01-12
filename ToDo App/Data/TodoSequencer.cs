using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App.Data
{
    public class TodoSequencer
    {
        private static int toDoId = 0;

        public static int nextToDoId()
        {
            return ++toDoId;
        }

        public static int reset()
        {
            toDoId = 0;
            return toDoId;
        }
    }
}

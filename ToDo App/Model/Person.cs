using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App.Model
{
    public class Person
    {       
        private readonly int personId;
        private string firstName;
        private string lastName;

        public int PersonId => personId;

        public Person(int personId = 0)
        {
            this.personId = personId;
            firstName = "";
            lastName = "";
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = NotNullOrEmpty(value);
            }
        }

        public String LastName
        {
            get => lastName;
            set
            {
                lastName = NotNullOrEmpty(value);
            }
        }

        private String NotNullOrEmpty(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty");
            }
            return value;
        }

    }

}

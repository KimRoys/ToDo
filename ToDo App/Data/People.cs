using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_App.Model;

namespace ToDo_App.Data
{
    public class People
    {
        private static Person[] personArr = new Person[0];

        public int Size()
        {
            return personArr.Length;
        }

        public Person[] FindAll()
        {
            return personArr;
        }

        public Person FindById(int personId)
        {
            foreach (Person person in personArr)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        public Person Add(String firstName, String lastName)
        {
            Person[] tmpArray = personArr;
            int newLength = personArr.Length + 1;
            personArr = new Person[newLength];

            if (personArr.Length > 1)
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    personArr[i] = tmpArray[i];
                }
            personArr[newLength - 1] = AddPerson(firstName, lastName);
            return personArr[newLength - 1];
        }

        private Person AddPerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.nextPersonId();
            Person person = new(personId);
            person.FirstName = firstName;
            person.LastName = lastName;
            return person;
        }

        public void Clear()
        {
            personArr = Array.Empty<Person>();
        }

        public void Remove(int id)
        {
            int indexId = findIndex(id);

            if (indexId > -1)
            {
                int newLength = personArr.Length - 1;
                Person[] tmpArr = personArr;
                personArr = new Person[newLength];

                int count = 0;
                for (int i = 0; i < tmpArr.Length; i++)
                {
                    if (i != indexId)
                    {
                        personArr[count] = tmpArr[i];
                        count++;
                    }
                }
            }
        }

        private int findIndex(int id)
        {
            for (int i = 0; i < personArr.Length; i++)
            {
                if (personArr[i].PersonId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

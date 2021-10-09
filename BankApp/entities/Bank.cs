using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.entities
{
    class Bank
    {
        public static List<Person> clientsList = new List<Person>();

        public static void Register(Person person)
        {
            clientsList.Add(person);
        }
    }
}

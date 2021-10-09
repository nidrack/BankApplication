using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp.entities
{
    class Bank
    {
        public static List<Person> clientsList = new List<Person>();

        public static void Register(Person person)
        {
            clientsList.Add(person);
        }

        public static bool ExistingAccount(int accNumber)
        {
            var listTemp = clientsList
                .Select(x => x.AccNumber)
                .ToList();
            return listTemp.Contains(accNumber);
        }

        public static string FirstClient()
        {
            var listTemp = clientsList
                .OrderBy(x => x.AccDate)
                .Take(1)
                .ToList();

            return $"{listTemp[0].Name} {listTemp[0].AccDate:d}\n";
        }

        public static List<Person> PoorClients()
        {
            var listTemp = clientsList
                .Where(x => x.Balance < 100.00)
                .ToList();

            return listTemp;
        }
    }
}

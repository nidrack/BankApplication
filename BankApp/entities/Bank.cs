using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp.entities
{
    class Bank
    {

        public static List<Person> ClientList = new List<Person>();
        public static double TotalLoanBalance => ClientList.Sum(x => x.Balance);

        public static void Register(Person person)
        {
            ClientList.Add(person);
        }

        public static void MergeList(List<Person> list)
        {
            ClientList.AddRange(list);
        }

        public static bool ExistingAccount(int accNumber)
        {
            var listTemp = ClientList
                .Select(x => x.AccNumber)
                .ToList();
            return listTemp.Contains(accNumber);
        }

        public static string FirstClient()
        {
            var listTemp = ClientList
                .OrderBy(x => x.CreationDate)
                .Take(1)
                .ToList();

            return $"{listTemp[0].Name} {listTemp[0].CreationDate:d}\n";
        }

        public static List<Person> PoorClients()
        {
            var listTemp = ClientList
                .Where(x => x.Balance < 100.00)
                .ToList();
            return listTemp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.entities
{
    class Person
    {
        public string Name { get; set; }
        public int AccNumber { get; set; }
        public DateTime AccDate { get; set; }
        public double Balance { get; private set; }

        public Person(string name, int accNumber, DateTime accDate, double balance)
        {
            Name = name;
            AccNumber = accNumber;
            AccDate = accDate;
            Balance = balance;
        }

        public void deposit(double amount)
        {
            Balance += amount;
        }

        public void withdraw(double amount)
        {
            try
            {
                if (amount > Balance)
                {
                    throw new Exception("Insuficient Funds");
                }
                else
                {
                    Balance -= amount;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

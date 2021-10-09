using System;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

using BankApp.entities;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Nome do cliente
            Console.Write("Name: ");
            string name = Console.ReadLine();

            // Número da conta do cliente
            Console.Write("Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());

            // Data de criação no momento de execução
            DateTime accDate = DateTime.Now;

            // Saldo inicial da conta
            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine());

            // Instanciação de um novo cliente na lista de clientes do banco
            Bank.Register(new Person(name, accNumber, accDate, balance));

        }
    }
}

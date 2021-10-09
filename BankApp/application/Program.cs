using System;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

using BankApp.entities;
using BankApp.services;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Bloco de adicionar novo cliente com entrada de dados

            // Nome do cliente
            Console.Write("Name: ");
            string name = Console.ReadLine();

            // Número da conta do cliente sem permitir repetição
            Console.Write("Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());
            if (Bank.ExistingAccount(accNumber))
            {
                Console.WriteLine("This account number is already in use. Try again: ");
                Console.Write("Account Number: ");
                accNumber = int.Parse(Console.ReadLine());
            }

            // Data de criação no momento de execução
            DateTime accDate = DateTime.Now;

            // Saldo inicial da conta
            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine());

            // Instanciação de um novo cliente na lista de clientes do banco
            Bank.Register(new Person(name, accNumber, accDate, balance));

            // Ver cliente mais antigo registrado
            Console.WriteLine($"First client: {Bank.FirstClient()}");

            // Ver clientes com saldo menor que 100
            Bank.PoorClients().ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}

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

            var fileName = "accounts.csv"; //Nome do arquivo
            var path = Path.Combine(
                            Environment.GetEnvironmentVariable("USERPROFILE"), // Pasta local do usuário
                            @"source\repos\BankApp\BankApp\", // Local do projeto a partir da pasta do usuário
                            fileName);
            try
            {
                var reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    Bank.Register(new Person(
                        values[0], // Name
                        int.Parse(values[1]), // AccNumber
                        DateTime.Parse(values[2]), // AccDate
                        double.Parse(values[3], new CultureInfo("en-US")) // Balance
                                    ));
                }
                Console.WriteLine("Import successful!");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

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

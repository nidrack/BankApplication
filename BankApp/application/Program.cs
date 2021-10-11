using System;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

using BankApp.entities;
using System.Linq;
using BankApp.services;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serviços da aplicação
            BankServices.Services.Add("Terminar operação", EndApplication);
            BankServices.Services.Add("Importar arquivo existente", ImportFile);
            BankServices.Services.Add("Adicionar novo cliente", AddNewClient);
            BankServices.Services.Add("Salvar o arquivo com novos dados", SaveFile); //fazer
            BankServices.Services.Add("Selecionar um cliente", SelectClient); //fazer
            BankServices.Services.Add("Ver cliente mais antigo", SeeOldestClient);
            BankServices.Services.Add("Ver clientes descapitalizados", SeePoorClients);
            BankServices.Services.Add("Ver saldo de empréstimo do banco", BankLoan);

            // Leitura e impressão dos serviços inseridos
            int i = 0;
            foreach (var item in BankServices.Services)
            {
                Console.WriteLine("{0} - {1}", i, item.Key);
                i++;
            }

            // Seleção do serviço a ser executado
            int a;
            do
            {
                Console.Write("Enter service number: ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Você selecionou: {0}", BankServices.Services.ElementAt(a).Key);
                BankServices.RunService(a);
            } while (a != 0);

            // Bloco de leitura de dados de arquivo em pasta local 
            static void ImportFile()
            {
                Console.WriteLine(BankServices.ImportDataJson());
            }

            // Encerrar aplicação
            static void SaveFile()
            {
                Console.WriteLine(BankServices.SaveData());
            }

            // Bloco de adicionar novo cliente com entrada de dados
            static void AddNewClient()
            {
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
                DateTime accDate = DateTime.Now.Date;

                // Saldo inicial da conta
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());

                // Instanciação de um novo cliente na lista de clientes do banco
                Bank.Register(new Person(name, accNumber, accDate, balance));
            }

        }

        // Selecionar um cliente para realizar uma operação
        static void SelectClient()
        {
        }

        // Ver cliente mais antigo registrado
        static void SeeOldestClient() => Console.WriteLine($"First client: {Bank.FirstClient()}");

        // Ver clientes com saldo menor que 100
        static void SeePoorClients() => Bank.PoorClients().ForEach(p => Console.WriteLine(p.ToString()));

        // Ver saldo de empréstimo do banco
        static void BankLoan()
        {
            Console.WriteLine($"Total loan amount: {Bank.TotalLoanBalance:c}");
        }

        // Encerrar aplicação
        static void EndApplication()
        {
        }
    }
}


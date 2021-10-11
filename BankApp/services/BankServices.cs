using BankApp.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BankApp.services
{
    class BankServices
    {
        public static string ImportDataJson()
        {
            var path = Path.Combine(
                            Environment.GetEnvironmentVariable("USERPROFILE"), // Pasta local do usuário
                            @"source\repos\BankApp\BankApp\", // Local do projeto a partir da pasta do usuário
                            @"accounts.json");
            var json = File.ReadAllText(path);
            var person = JsonConvert.DeserializeObject<List<Person>>(json);
            Bank.MergeList(person);
            return "Import sucessesful!";
        }

        public static string SaveData()
        {
            var path = Path.Combine(
                            Environment.GetEnvironmentVariable("USERPROFILE"), // Pasta local do usuário
                            @"source\repos\BankApp\BankApp\", // Local do projeto a partir da pasta do usuário
                            @"accounts.json");
            var json = JsonConvert.SerializeObject(Bank.ClientList.ToArray());
            File.WriteAllText(path, json);
            return "Save sucessesful!";
        }

        public static Dictionary<string, Action> Services = new Dictionary<string, Action>();

        public static void RunService(int i)
        {
            Action executar = Services.ElementAt(i).Value;
            executar();
        }
    }

}

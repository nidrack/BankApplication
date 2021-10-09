using BankApp.entities;
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

        public static string ImportData(string path)
        { 
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
                return "Import successful!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public static string SaveData()
        {
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

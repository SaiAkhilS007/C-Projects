using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExpenseTracker
{
    class Program
    {
        static List<Expense> expenses = new();

        static void Main(string[] args)
        {
            Load();
            while (true)
            {
                Console.WriteLine("\nExpense Tracker");
                Console.WriteLine("1. Add expense");
                Console.WriteLine("2. List expenses");
                Console.WriteLine("3. Save and exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddExpense();
                        break;
                    case "2":
                        ListExpenses();
                        break;
                    case "3":
                        Save();
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddExpense()
        {
            Console.Write("Date (yyyy-MM-dd): ");
            var date = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Description: ");
            var desc = Console.ReadLine();
            Console.Write("Amount: ");
            var amount = decimal.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            expenses.Add(new Expense { Date = date, Description = desc!, Amount = amount });
        }

        static void ListExpenses()
        {
            Console.WriteLine("\nDate\tDescription\tAmount");
            foreach (var e in expenses.OrderBy(e => e.Date))
            {
                Console.WriteLine($"{e.Date:yyyy-MM-dd}\t{e.Description}\t{e.Amount:C}");
            }
        }

        static void Load()
        {
            if (!File.Exists("expenses.csv")) return;
            var lines = File.ReadAllLines("expenses.csv");
            foreach (var line in lines)
            {
                var parts = line.Split(",");
                expenses.Add(new Expense
                {
                    Date = DateTime.Parse(parts[0]),
                    Description = parts[1],
                    Amount = decimal.Parse(parts[2], CultureInfo.InvariantCulture)
                });
            }
        }

        static void Save()
        {
            var lines = expenses.Select(e => $"{e.Date:yyyy-MM-dd},{e.Description},{e.Amount.ToString(CultureInfo.InvariantCulture)}");
            File.WriteAllLines("expenses.csv", lines);
            Console.WriteLine("Data saved to expenses.csv");
        }
    }

    class Expense
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }
    }
}

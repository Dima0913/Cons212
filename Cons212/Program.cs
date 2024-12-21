using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}

public class Company
{
    public string Name { get; set; }
    public DateTime Founded { get; set; }
    public string BusinessProfile { get; set; }
    public string Director { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }
    public List<Employee> Employees { get; set; }
}

class Program
{
    static void Main()
    {
        // Дані
        var companies = new List<Company>
        {
            new Company
            {
                Name = "FoodTech",
                Founded = DateTime.Now.AddYears(-5),
                BusinessProfile = "Marketing",
                Director = "John White",
                EmployeeCount = 150,
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Manager", Phone = "231234567", Email = "messi@example.com", Salary = 5000 },
                    new Employee { FullName = "Diana Ross", Position = "Developer", Phone = "231111222", Email = "diana.ross@example.com", Salary = 4000 }
                }
            },
            new Company
            {
                Name = "IT WhiteTech",
                Founded = DateTime.Now.AddYears(-1).AddDays(-123),
                BusinessProfile = "IT",
                Director = "Jack Black",
                EmployeeCount = 250,
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Developer", Phone = "234567890", Email = "lionel@blacktech.com", Salary = 5500 },
                    new Employee { FullName = "Diana White", Position = "Manager", Phone = "239876543", Email = "di.white@example.com", Salary = 7000 }
                }
            },
            new Company
            {
                Name = "Green Food",
                Founded = DateTime.Now.AddYears(-3),
                BusinessProfile = "Agriculture",
                Director = "Susan Green",
                EmployeeCount = 50,
                Address = "Manchester",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "George Clooney", Position = "Farmer", Phone = "231234987", Email = "george@example.com", Salary = 3000 }
                }
            }
        };

        // Виклик запитів
        PrintResults("Усі фірми", companies.Select(c => c.Name));

        PrintResults("Фірми, які мають у назві слово 'Food'",
            companies.Where(c => c.Name.Contains("Food")).Select(c => c.Name));

        PrintResults("Фірми, які працюють у галузі маркетингу",
            companies.Where(c => c.BusinessProfile == "Marketing").Select(c => c.Name));

        PrintResults("Фірми, які працюють у галузі маркетингу або IT",
            companies.Where(c => c.BusinessProfile == "Marketing" || c.BusinessProfile == "IT").Select(c => c.Name));

        PrintResults("Фірми з кількістю працівників більшою, ніж 100",
            companies.Where(c => c.EmployeeCount > 100).Select(c => c.Name));

        PrintResults("Фірми з кількістю працівників у діапазоні від 100 до 300",
            companies.Where(c => c.EmployeeCount >= 100 && c.EmployeeCount <= 300).Select(c => c.Name));

        PrintResults("Фірми, які знаходяться в Лондоні",
            companies.Where(c => c.Address == "London").Select(c => c.Name));

        PrintResults("Фірми, в яких прізвище директора White",
            companies.Where(c => c.Director.Contains("White")).Select(c => c.Name));

        PrintResults("Фірми, які засновані більше двох років тому",
            companies.Where(c => c.Founded < DateTime.Now.AddYears(-2)).Select(c => c.Name));

        PrintResults("Фірми, з дня заснування яких минуло 123 дні",
            companies.Where(c => (DateTime.Now - c.Founded).Days == 123).Select(c => c.Name));

        PrintResults("Фірми, в яких прізвище директора Black і мають у назві слово 'White'",
            companies.Where(c => c.Director.Contains("Black") && c.Name.Contains("White")).Select(c => c.Name));

        // Запити для працівників
        PrintResults("Працівники FoodTech",
            companies.First(c => c.Name == "FoodTech").Employees.Select(e => e.FullName));

        PrintResults("Працівники FoodTech із зарплатою більше 4000",
            companies.First(c => c.Name == "FoodTech").Employees.Where(e => e.Salary > 4000).Select(e => e.FullName));

        PrintResults("Працівники з посадою 'Менеджер'",
            companies.SelectMany(c => c.Employees).Where(e => e.Position == "Manager").Select(e => e.FullName));

        PrintResults("Працівники, телефон яких починається з '23'",
            companies.SelectMany(c => c.Employees).Where(e => e.Phone.StartsWith("23")).Select(e => e.FullName));

        PrintResults("Працівники, Email яких починається з 'di'",
            companies.SelectMany(c => c.Employees).Where(e => e.Email.StartsWith("di")).Select(e => e.FullName));

        PrintResults("Працівники з ім'ям Lionel",
            companies.SelectMany(c => c.Employees).Where(e => e.FullName.Contains("Lionel")).Select(e => e.FullName));
    }

    static void PrintResults(string title, IEnumerable<string> results)
    {
        Console.WriteLine($"--- {title} ---");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine();
    }
}

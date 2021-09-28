using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {

        static List<Employee> GetEmployees()
        {
            // return a list of strings
            List<Employee> employees = new List<Employee>();
            // Collect user values until the value is an empty string
            while (true)
            {
                Console.WriteLine("Enter first name (leave empty to exit): ");
                string firstName = Console.ReadLine();
                // Break if the user hits ENTER without typing a name
                if (firstName == "")
                {
                    break;
                }
                Console.WriteLine("Enter a Last Name: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Photo URL:");
                // https://placekitten.com/300/300
                string photoUrl = Console.ReadLine();
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }
        // static void PrintEmployees(List<Employee> employees)
        // {
        //     for (int i = 0; i < employees.Count; i++)
        //     {
        //         string template = "{0,-10}\t{1,-20}\t{2}";
        //         Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
        //     }
        // }
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            Util.PrintEmployees(employees);
            // run CSV creation method
            Util.MakeCSV(employees);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;


namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
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
                // http://www.fillmurray.com/300/300
                string photoUrl = Console.ReadLine();
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }

        public static List<Employee> GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                foreach (JToken token in json.SelectToken("results"))
                {
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}

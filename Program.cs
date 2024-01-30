using System;
using System.Data.SqlClient;
using Dapper;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-JI1JKUA\\SQLEXPRESS;Database=Employees;Trusted_Connection=true";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var employees = connection.Query<Employee>("SELECT * FROM Employee");

            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Salary: {employee.Salary}");
            }

            var specificEmployee = connection.QueryFirstOrDefault<Employee>("SELECT * FROM Employee WHERE Id = @Id", new { Id = 1 });


            connection.Close();
        }
    }
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; } = 0.0m;
    }

}


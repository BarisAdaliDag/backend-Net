using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_OOP_Relationship
{
    public class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {Salary}";
        }
    }

    public class Developer : Employee
    {
        public Developer(string name, decimal salary, List<string> programmingLanguages) : base(name, salary)
        {
            ProgrammingLanguages = programmingLanguages;
        }

        public List<string> ProgrammingLanguages { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\nProgramming Languages: " + string.Join(", ", ProgrammingLanguages);
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Team { get; set; }
        public Manager(string name, decimal salary) : base(name, salary)
        {
            Team = new List<Employee>();
        }

        public void AddToTeam(Employee employee)
        { 
            Team.Add(employee);
        }

        public override string ToString()
        {
            string member = "";
            foreach (Employee emp in Team) 
            { 
                member += emp.ToString() + "\n";
            }
            return base.ToString() + "Team Members: \n" + member; 
        }
    }
}

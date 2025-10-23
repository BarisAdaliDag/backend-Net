using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
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
            return $"Name {Name} Salary {Salary}";
        }
    }
    public class Developer : Employee
    {
        public Developer(string name, decimal salary, List<string> programLanguaces) : base(name, salary)
        {
            ProgramLanguaces = programLanguaces;
        }
        public List<string> ProgramLanguaces { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\n Programming languace {String.Join(",",ProgramLanguaces)}";
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, decimal salary, List<Employee> team) : base(name, salary)
        {
            Team = team;
        }
        public List<Employee> Team { get; set; }

        public override string ToString()
        {
           string mem

        }
    }


}


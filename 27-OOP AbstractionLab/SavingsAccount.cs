using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_OOP_AbstractionLab
{
    internal class SavingsAccount : BankAccount

    {
        private double _interestRate = 0.03;//faiz orani
        public SavingsAccount(string accountNumber, string accountName) : base(accountNumber, accountName)
        {
         
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} into saving account.\nTotal balance : {Balance}");
            AddInterest();
        }

        public override void WithDraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                Console.WriteLine($"WithDraw {amount} into saving account.\nTotal balance : {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdraw");
            }
        }
        public void AddInterest()
        {
            Balance += Balance * _interestRate;
            Console.WriteLine($"Intrest adde. Balance {Balance}");

        }
    }
}

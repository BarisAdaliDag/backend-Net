using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_OOP_AbstractionLab
{
    public class CurrentAccount : BankAccount
    {

        private double _overdraftLimit = 5000;
        public CurrentAccount(string accountNumber, string accountName) : base(accountNumber, accountName)
        {
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} into current account.\nTotal balance : {Balance}");
        }

        public override void WithDraw(double amount)
        {
            if (Balance - amount >= -_overdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"WithDraw {amount} into current account.\nTotal balance : {Balance}");
            }
            else
            {
                Console.WriteLine("Withdraw exceeds overdraft limit.");
            }
        }
    }
    //public class deneme : BankAccount
    //{
    //    public deneme(string accountNumber, string accountName) : base(accountNumber, accountName)
    //    {
    //    }

    //    public override void Deposit(double amount)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WithDraw(double amount)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

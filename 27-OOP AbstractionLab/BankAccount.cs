using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_OOP_AbstractionLab
{
    public abstract class BankAccount
    {
        public BankAccount(string accountNumber, string accountName)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
        }

        public string AccountNumber { get;private set; }
        public string AccountName { get;private set; }
        public double Balance { get; set; }

        public abstract void Deposit(double amount);
        public abstract void WithDraw(double amount);

        public override string ToString()
        {
            return $"Account Number :{AccountNumber} , Account Holder: {AccountName} Balance:{Balance}";
        }

    }
}

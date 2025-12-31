using System;

namespace SimpleBankingSystem
{
    public class Account
    {
        public int AccountNumber { get; }
        public string OwnerName { get; }
        public decimal Balance { get; private set; }

        public Account(int accountNumber, string ownerName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid deposit amount.");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid withdrawal amount.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
        }
    }
}

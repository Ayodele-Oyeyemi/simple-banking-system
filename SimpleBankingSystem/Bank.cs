using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBankingSystem
{
    public class Bank
    {
        private readonly List<Account> accounts = new();
        private int nextAccountNumber = 1001;

        public Account CreateAccount(string ownerName, decimal initialBalance)
        {
            var account = new Account(nextAccountNumber++, ownerName, initialBalance);
            accounts.Add(account);
            return account;
        }

        public Account? GetAccount(int accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}

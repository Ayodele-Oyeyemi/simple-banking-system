using System;
using SimpleBankingSystem;

class Program
{
    static void Main()
    {
        var bank = new Bank();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Simple Banking System ---");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Owner name: ");
                        string name = Console.ReadLine() ?? "";

                        Console.Write("Initial deposit: ");
                        decimal initial = decimal.Parse(Console.ReadLine()!);

                        var acc = bank.CreateAccount(name, initial);
                        Console.WriteLine($"Account created. Number: {acc.AccountNumber}");
                        break;

                    case "2":
                        var depositAcc = GetAccountInput(bank);
                        Console.Write("Amount: ");
                        depositAcc.Deposit(decimal.Parse(Console.ReadLine()!));
                        Console.WriteLine("Deposit successful.");
                        break;

                    case "3":
                        var withdrawAcc = GetAccountInput(bank);
                        Console.Write("Amount: ");
                        withdrawAcc.Withdraw(decimal.Parse(Console.ReadLine()!));
                        Console.WriteLine("Withdrawal successful.");
                        break;

                    case "4":
                        var balanceAcc = GetAccountInput(bank);
                        Console.WriteLine($"Balance: ₦{balanceAcc.Balance}");
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static Account GetAccountInput(Bank bank)
    {
        Console.Write("Account number: ");
        int accNum = int.Parse(Console.ReadLine()!);

        var account = bank.GetAccount(accNum);
        if (account == null)
            throw new Exception("Account not found.");

        return account;
    }
}


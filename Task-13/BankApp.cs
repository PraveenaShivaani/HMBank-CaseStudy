﻿using System.Net;
using System.Text.RegularExpressions;

namespace Task_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Account Balance");
                Console.WriteLine("5. List of Accounts");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 2:
                        Deposit(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 3:
                        Withdraw(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 4:
                        GetAccountBalance(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 5:
                        ListOfAccounts(bank);
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                }
            }
        }

        public static void CreateAccount(Bank bank)
        {
            
            Console.WriteLine("Enter First Name:");
            string Name = Console.ReadLine();

        
            string emailAddress = null;
        Email:
            try
            {
                Console.WriteLine("Enter Email Address:");
                emailAddress = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(emailAddress, pattern))
                {
                    throw new ArgumentException("Invalid email address format.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Email;
            }

            string phoneNumber = null;
        phoneNumber:
            try
            {
                Console.WriteLine("Enter Phone Number:");
                phoneNumber = Console.ReadLine();
                //Validating phone nnumber
                string pattern = @"^\d{10}$";
                if (!Regex.IsMatch(phoneNumber, pattern))
                {
                    throw new ArgumentException("Invalid phone number format. Please enter a 10-digit phone number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto phoneNumber;
            }

            Console.WriteLine("Enter Account Type (Savings/Current):");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Initial Balance:");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            bank.CreateAccount(accountType, initialBalance, Name, phoneNumber, emailAddress);
        }

        public static void Deposit(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Deposit Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bank.Deposit(accountNumber, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void Withdraw(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Withdraw Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bank.Withdraw(accountNumber, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void GetAccountBalance(Bank bank)
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            try
            {
                decimal balance = bank.GetAccountBalance(accountNumber);
                Console.WriteLine($"Current Balance: {balance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ListOfAccounts(Bank bank)
        {
            bank.ListOfAccounts();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WK9BankingProgram1
{
    class Account
    {
        #region FIELDS
        private Client client;
        private string accountNumber;
        private double balance;
        private string filePath;
        #endregion

        #region PROPERTIES
        public Client Client
        {
            get { return client; }
            set { client = value; }
        }
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Account()
        { }
        public Account(Client client)
        {
            this.client = client;
            accountNumber = $"AccountType{client.ClientID}";
            balance = 0.00;
            filePath = @"AccountSummary_" + accountNumber;
            StreamWriter fileSW = new StreamWriter(filePath);
            using (fileSW)
            {
                fileSW.WriteLine($"Client: {client.FullName}");
                fileSW.WriteLine($"Account Number: {accountNumber}");
                fileSW.WriteLine($"Current Balance: ${balance}");
            }
        }
        #endregion

        #region METHODS
        public bool Withdraw(double amount)
        {
            if (balance - amount >= 0 && amount > 0)
            {
                balance = balance - amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance = balance + amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CheckBalance()
        {
            Console.WriteLine($"Account: {accountNumber} \nCurrent Balance: ${balance}");
        }
        #endregion
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu("MAIN MENU:", new List<string> { "View Client Information", "View Account Balance", "Deposit Funds", "Withdraw Funds", "Exit" });
            Menu accountMenu = new Menu("ACCOUNTS:", new List<string> { "Checking", "Reserve", "Savings" });
            Client client1 = new Client("Marpy", "Winkelman");
            bool repeat = true;
            while (repeat == true)
            {
                int menuInput = mainMenu.RunMenu();
                switch (menuInput)
                {
                    case 1:
                        client1.ViewClientInfo();
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case 2:
                        Console.WriteLine("Please choose an account by entering the menu number: ");
                        int balanceInput = accountMenu.RunMenu();
                         
                        switch (balanceInput)
                        {
                            case 1:
                                client1.Checking.CheckBalance();                                
                                break;
                            case 2:
                                client1.Reserve.CheckBalance();
                                break;
                            case 3:
                                client1.Savings.CheckBalance();
                                break;
                            default:
                                Console.WriteLine("Error: Nonvalid entry\nPress ENTER to return to the Main Menu.");
                                break;
                        }
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case 3:
                        Console.WriteLine("Please choose an account by entering the menu number: ");
                        int depositInput = accountMenu.RunMenu();
                        switch (depositInput)
                        {
                            case 1:
                                DepositFunds(client1.Checking);
                                break;
                            case 2:
                                DepositFunds(client1.Reserve);
                                break;
                            case 3:
                                DepositFunds(client1.Savings);
                                break;
                            default:
                                Console.WriteLine("Error: Nonvalid entry\nPress ENTER to return to the Main Menu.");
                                break;
                        }
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case 4:
                        Console.WriteLine("Please choose an account by entering the menu number: ");
                        int withdrawalInput = accountMenu.RunMenu();

                        switch (withdrawalInput)
                        {
                            case 1:
                                WithdrawFunds(client1.Checking);
                                break;
                            case 2:
                                WithdrawFunds(client1.Reserve);
                                break;
                            case 3:
                                WithdrawFunds(client1.Savings);
                                break;
                            default:
                                Console.WriteLine("Error: Nonvalid entry\nPress ENTER to return to the Main Menu.");
                                break;
                        }
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case 5:
                        repeat = false;
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        break;
                }
            }
            Console.Read();
            client1.Checking.Deposit(45);
            client1.Reserve.Deposit(60);
            client1.Savings.Deposit(15);
            client1.ViewClientInfo();

            Console.Read();
        }
        //static string DisplayMenu()
        //{
        //    List<string> menuItems = new List<string>
        //    {"View Client Information","View Account Balance","Deposit Funds","Withdraw Funds","Exit"};
        //    Console.Clear();
        //    Console.WriteLine("PERSONAL BANKING SYSTEM\n");
        //    int counter = 0;
        //    Console.WriteLine("MENU:\n-----------------");
        //    foreach (string item in menuItems)
        //    {
        //        counter++;
        //        Console.WriteLine($"{counter}. {item}");
        //    }
        //    Console.WriteLine("Enter the number of a menu item:");
        //    string input = Console.ReadLine();
        //    return input;
        //}
        static void DepositFunds(Account account)
        {
            Console.WriteLine("Enter amount:");
            string input = Console.ReadLine();
            double amount;
            bool test = double.TryParse(input, out amount);
            if (!test)
                return;

            bool allow = account.Deposit(amount);
            if (allow == true)
            {
                StreamWriter sw = new StreamWriter(account.FilePath, true);
                DateTime dateTime = DateTime.Now;
                using (sw)
                {
                    sw.WriteLine($"{dateTime}:  + ${amount},  Current Balance: ${account.Balance}");
                }
                Console.Clear();
                StreamReader sr = new StreamReader(account.FilePath);
                using (sr)
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            else { Console.WriteLine("Error: nonvalid amount"); }
        }
        static void WithdrawFunds(Account account)
        {
            Console.WriteLine("Enter amount:");
            string input = Console.ReadLine();
            double amount;
            bool test = double.TryParse(input, out amount);
            if (!test)
                return;

            bool allow = account.Withdraw(amount);

            if (allow == true)
            {
                StreamWriter sw = new StreamWriter(account.FilePath, true);
                DateTime dateTime = DateTime.Now;
                using (sw)
                {
                    sw.WriteLine($"{dateTime}:  - ${amount},  Current Balance: ${account.Balance}");
                }
                Console.Clear();
                StreamReader sr = new StreamReader(account.FilePath);
                using (sr)
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            else { Console.WriteLine("Error: Insufficient funds or nonvalid amount"); }
        }
    }
}

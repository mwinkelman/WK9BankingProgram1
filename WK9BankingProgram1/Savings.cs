using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WK9BankingProgram1
{
    class Savings : Account
    {
        private double minimumBalance;
        private bool activated;
        public double MinumumBalance
        {
            get { return minimumBalance; }
            set { minimumBalance = value; }
        }
        public Savings()
        { }
        public Savings(Client client)
        {
            Client = client;
            AccountNumber = $"S_{client.ClientID}";
            Balance = 0.00;
            FilePath = @"AccountSummary_" + AccountNumber+".txt";
            StreamWriter fileSW = new StreamWriter(FilePath);
            activated = true;
            using (fileSW)
            {
                if (activated == false)
                    fileSW.WriteLine("(This account is inactive.)");
                fileSW.WriteLine($"Client: {client.FullName}");
                fileSW.WriteLine($"Account Number: {AccountNumber}");
                fileSW.WriteLine($"Current Balance: ${Balance}");
            }
        }
    }

}

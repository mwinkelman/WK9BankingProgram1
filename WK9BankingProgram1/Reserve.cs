using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WK9BankingProgram1
{
    class Reserve : Account
    {
        private double minimumBalance;
        private bool activated;
        public Reserve()
        { }
        public Reserve(Client client)
        {
            Client = client;
            AccountNumber = $"R_{client.ClientID}";
            Balance = 0.00;
            FilePath = @"AccountSummary_" + AccountNumber;
            activated = true;
            StreamWriter fileSW = new StreamWriter(FilePath);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WK9BankingProgram1
{
    class Checking : Account
    {
        #region FIELDS
        private double minimumBalance;
        private bool activated;
        #endregion

        #region PROPERTIES
        public double MinimumBalance
        {
            get { return minimumBalance; }
            set { minimumBalance = value; }
        }
        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Checking()
        { }
        public Checking(Client client)
        {
            Client = client;
            AccountNumber = $"C_{client.ClientID}";
            Balance = 0.00;
            FilePath = @"AccountSummary_" + AccountNumber+".txt";
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
        #endregion

        #region METHODS
        public void Activate()
        {
            activated = true;
        }
        public void Deactivate()
        {
            activated = false;
        }

        #endregion

    }
}

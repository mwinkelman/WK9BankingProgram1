using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK9BankingProgram1
{
    class Client
    {
        #region FIELDS
        private string firstName;
        private string lastName;
        private string clientID;
        private Checking checking;
        private Reserve reserve;
        private Savings savings;
        #endregion

        #region PROPERTIES 
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Lastname
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FullName
        {
            get{ return firstName + " " + lastName; }
        }
        public string ClientID
        {
            get { return clientID; }
        }
        public Checking Checking
        {
            get { return checking; }
        }
        public Reserve Reserve
        {
            get { return reserve; }
        }
        public Savings Savings
        {
            get { return savings; }
        }


        #endregion

        #region CONSTRUCTORS
        public Client(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName=lastName;
            Random idGenerator = new Random();
            clientID = idGenerator.Next().ToString();
            checking = new Checking(this);
            reserve = new Reserve(this);
            savings = new Savings(this);
        }
        #endregion

        #region METHODS
        public void ViewClientInfo()
        {
            StringBuilder fileSB = new StringBuilder("Client: ");
            fileSB.AppendLine(FullName);
            fileSB.AppendLine($"Checking Account: {checking.AccountNumber}");
            fileSB.AppendLine($"Balance: ${checking.Balance}");
            fileSB.AppendLine();
            fileSB.AppendLine($"Reserve Account: {reserve.AccountNumber}");
            fileSB.AppendLine($"Balance: ${reserve.Balance}");
            fileSB.AppendLine();
            fileSB.AppendLine($"Savings Account: {savings.AccountNumber}");
            fileSB.AppendLine($"Balance: ${savings.Balance}");
            fileSB.AppendLine();
            string clientFile = fileSB.ToString();
            Console.WriteLine(clientFile);
        }
        #endregion
    }
}

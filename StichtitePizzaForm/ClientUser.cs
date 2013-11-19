using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StichtitePizzaForm
{
    class ClientUser:User
    {
        string accountName;
        string password;
        AccountType type;
        string info;// or string[] info or string anem; string adress; string phone; etc.

        public ClientUser (string accountName, string password, AccountType type, string info)
        {
            this.accountName = accountName;
            this.password = password;
            this.type = type;
            this.info = info;
        }

        public string AccountName
        {
            get { return this.accountName; }
            set { this.accountName = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public AccountType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        public override void EditAccInfo(string accountName, string password, AccountType type)
        {
            throw new NotImplementedException();
            //log it? seems pointless for clients.
        }

        /*
         * other methods for the client:
         * 
         */
    }
}

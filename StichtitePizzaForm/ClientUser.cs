using System;
using System.Linq;

namespace StichtitePizzaForm
{
    class ClientUser : User
    {
        string accountName;
        string password;
        AccountType type;
        string adress;
        string phone;// or string[] info or string anem; string adress; string phone; etc.

        public ClientUser(string accountName, string password, AccountType type, string adress, string phone)
        {
            this.AccountName = accountName;
            this.Password = password;
            this.Type = type;
            this.Adress = adress;
            this.Phone = phone;
        }

        public string AccountName
        {
            get
            {
                return this.accountName;
            }
            set
            {
                this.accountName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public AccountType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Adress
        {
            get
            {
                return this.adress;
            }
            set
            {
                this.adress = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
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
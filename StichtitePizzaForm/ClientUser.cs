using System;
using System.Linq;
using System.IO;

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

        public void ConfirmOrder (Order clientOrder) //the instance of the order class created by pressing the confirm order button
        {
            string[] orderInfo= new string[3];
            orderInfo[0]=clientOrder.ToString();
            orderInfo[1]=this.Adress;
            orderInfo[2]=this.Phone;
            CSVEditing.CSVEditor saveOrder = new CSVEditing.CSVEditor(orderInfo, "CurrentOrders.csv");
            saveOrder.ArrayToLine(true);
        }
        /*
        * other methods for the client:
        * 
        */
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StichtitePizzaForm
{
    class EmployeeUser:User
    {
        string accountName;
        string password;
        AccountType type;
        string info;// or string[] info or string anem; string adress; string phone; etc.

        public EmployeeUser (string accountName, string password, AccountType type, string info)
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
            //log it too maybe? what does it edit (as in again whats held t=in the tables we read from and write into)
        }
        /*
         * other possible methods for the class:
         * ViewOrders(list<Order>) shows all available orders on the interface (suppose we have a classw called Order)
         * TakeOrder(Order) "binds" an order ot the employee adn removes it from the list of available once (the one that is the argument of the other method)
         * EndOrder(Order) 
         * etc.
         */
    }
}

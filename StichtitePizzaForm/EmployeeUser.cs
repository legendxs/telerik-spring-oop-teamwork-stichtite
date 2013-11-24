using System;
using System.Linq;

namespace StichtitePizzaForm
{
    class EmployeeUser:User
    {
        string accountName;
        string password;
        AccountType type;
        string adress;
        string phone;
        decimal earnings;// or string[] info or string anem; string adress; string phone; etc.

        public EmployeeUser (string accountName, string password, AccountType type, string adress, string phone, decimal earnings)
        {
            this.accountName = accountName;
            this.password = password;
            this.type = type;
            this.adress = adress;
            this.phone = phone;
            this.earnings = earnings;
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

        public string Adress
        {
            get { return this.adress; }
            set { this.adress = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public decimal Earnings
        {
            get { return this.earnings; }
            set { this.earnings = value; }
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

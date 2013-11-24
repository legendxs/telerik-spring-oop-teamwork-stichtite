using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StichtitePizzaForm
{
    class AdminUser : User
    {
        string accountName;
        string password;
        AccountType type;
        string adress;
        string phone;
        // or string[] info or string anem; string adress; string phone; etc.

        public AdminUser (string accountName, string password, AccountType type, string adress, string phone)
        {
            this.accountName = accountName;
            this.password = password;
            this.type = type;
            this.adress = adress;
            this.phone = phone;
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
        override public void EditAccInfo(string accountName, string password, AccountType type)
        {
            //edits the information in the table holding it for the apropriate account type (again what do we put in thouse?)
            using (StreamWriter logWritter= new StreamWriter("Log.txt"))
            {
                logWritter.WriteLine("something explaining what admin did what to what employee acc");
            }
        }
        /* 
         * other possible methods:
         * FireEmployee(string accountName); deltes the employee entry from the table (and maybe  converts it to client entry)
         * DeductPay(string accountName); 
         * EditMenu (); edits the menu will need this one for sure
         * PayEmplyees(); resets the "hoursWorked" (or something)  on all entries in the emplyee table
         */
    }
}

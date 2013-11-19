using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StichtitePizzaForm
{
    abstract class User : IUser
    {
        public void CreateAcc(string accountName, string password,AccountType type)
        {
            bool doesAccountExist=false;
            using (StreamReader checkExisting= new StreamReader("Accounts.csv"))
            {
                
               string[] accountCheck= checkExisting.ReadLine().Split(',');
               if (accountCheck[0] == accountName)
                   doesAccountExist = true;
            }
            if (doesAccountExist)
            {/*returns some error in the UI and puts up the account creation screen again*/}
            else
            {
                StringBuilder accountInfo = new StringBuilder();
                accountInfo.Append(accountName);
                accountInfo.Append(";");
                accountInfo.Append(password);
                accountInfo.Append(";");
                switch (type)
                {
                    case AccountType.Admin:
                        accountInfo.Append("Admin");
                        //creates an entry into the table with the admin accounts (what info will that table hold?)
                        break;
                    case AccountType.Employee:
                        accountInfo.Append("Employee");
                        //creates an entry into the table with the employee accounts (what info will that table hold?)
                        break;
                    case AccountType.Client:
                        accountInfo.Append("Client");
                        //creates an entry into the table with the client accounts (what info will that table hold?)
                        break;
                    default:
                        //some error message? can this even happen with enumeration?
                        break;
                }
                using (StreamWriter accountCreator=new StreamWriter("Accounts.csv"))
                {
                    accountCreator.WriteLine(accountInfo.ToString());
                }
            }//else end

        }//method end
        public void LogIn(string accountName, string password)
        {
            bool isLogInCOrrect = false;
            using (StreamReader checkExisting = new StreamReader("Accounts.csv"))
            {

                string[] accountCheck = checkExisting.ReadLine().Split(',');
                if (accountCheck[0] == accountName&&accountCheck[1]==password)
                {isLogInCOrrect = true;}

                if (isLogInCOrrect)
                {
                    switch (accountCheck[3])
                    {
                        case "Admin":
                            //Creates an instance of the Admin class by reading the proper values for the properties from the table with the admin accounts
                            AdminUser loggedAdmin = new AdminUser (accountCheck[0], accountCheck[1], AccountType.Admin, "will be read from table");
                            //checks wich line to read by account name
                            //is this even possible? or do we leave the method abstract and then have it implemented in 3 different ways in the sub classes?
                            //if it is, is it better ?
                            break;
                        case "Employee":
                            //see above
                            break;
                        case "Client":
                            //see above
                            break;
                        default:
                            //again do we need that or do we use it as a third option (enumeration)
                            break;
                    }
                }//if end
                else
                {
                    //puts some error on the UI and calls the log in screen again
                }
            }//using end
        }//method end

        abstract public void EditAccInfo(string accountName, string password, AccountType type);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StichtitePizzaForm
{
    abstract class User : IUser
    {
        public static void CreateAcc(string accountName, string password,AccountType type, string adress, string phone)
        {
            bool doesAccountExist=false;
            using (StreamReader checkExisting = new StreamReader("Accounts.csv"))
            {
                string checkExistingLine = checkExisting.ReadLine();
                string[] accountCheck = checkExistingLine.Split(',');
                while (checkExistingLine!= null)
                {
                    accountCheck = checkExistingLine.Split(',');
                    if (accountCheck[0] == accountName)
                    {
                    doesAccountExist = true;
                    break;
                    }
                    checkExistingLine=checkExisting.ReadLine();
                    
                }
            }
            if (doesAccountExist)
            { MessageBox.Show("Account with that name already exists. Please choose another"); }
            else
            {
                
                
                StringBuilder accountInfo = new StringBuilder();
                accountInfo.Append(accountName);
                accountInfo.Append(",");
                accountInfo.Append(password);
                accountInfo.Append(",");
                switch (type)
                {
                    case AccountType.Admin:
                        accountInfo.Append("Admin");
                        using (StreamWriter accountCreator= new StreamWriter("Accounts.csv",true))
                        {
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        using (StreamWriter accountCreator=new StreamWriter("Admins.csv", true))
                        {
                            accountInfo.Clear();
                            accountInfo.Append(accountName + "," + adress + "," + phone);
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        MessageBox.Show("Registration Sucsessfull");
                        break;

                    case AccountType.Employee:
                        accountInfo.Append("Employee");
                        using (StreamWriter accountCreator = new StreamWriter("Accounts.csv", true))
                        {
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        using (StreamWriter accountCreator = new StreamWriter("Employyes.csv", true))
                        {
                            accountInfo.Clear();
                            accountInfo.Append(accountName + "," + adress + "," + phone+"0");
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        MessageBox.Show("Registration Sucsessfull");
                        break;

                    case AccountType.Client:
                        accountInfo.Append("Client");
                        using (StreamWriter accountCreator = new StreamWriter("Accounts.csv", true))
                        {
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        using (StreamWriter accountCreator = new StreamWriter("Clients.csv", true))
                        {
                            accountInfo.Clear();
                            accountInfo.Append(accountName + "," + adress + "," + phone);
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        MessageBox.Show("Registration Sucsessfull");
                        //creates an entry into the table with the client accounts 
                        break;
                    default:
                        //some error message? can this even happen with enumeration?
                        break;
                }
                
            }//else end

        }//method end
        public static void LogIn(string accountName, string password)
        {
            bool isLogInCOrrect = false;
            string phone = " ";
            string adress = " ";
            using (StreamReader checkExisting = new StreamReader("Accounts.csv"))
            {
                string accountTableLine = checkExisting.ReadLine();
                string[] accountCheck = accountTableLine.Split(',');
                while (accountTableLine != null)
                {
                    accountCheck = accountTableLine.Split(',');
                    if (accountCheck[0] == accountName && accountCheck[1] == password)
                    {
                        isLogInCOrrect = true;
                        break;
                    }
                    accountTableLine = checkExisting.ReadLine();
                }
                

                if (isLogInCOrrect)
                {
                    switch (accountCheck[2])
                    {
                        case "Admin":
                            //Creates an instance of the Admin class by reading the proper values for the properties from the table with the admin accounts

                            string adminTableLine;
                            using (StreamReader AdminInfo = new StreamReader("Admins.csv"))
                            {
                                adminTableLine = AdminInfo.ReadLine();
                                string[] adminCheck = adminTableLine.Split(',');
                                while (adminTableLine != null)
                                {
                                    if (adminCheck[0] == accountCheck[0])
                                    {
                                        adress = adminCheck[1];
                                        phone = adminCheck[2];
                                        break;
                                    }
                                }
                            }
                            AdminUser loggedAdmin = new AdminUser(accountCheck[0], accountCheck[1], AccountType.Admin,  adress,  phone);
                            MessageBox.Show("Log in successfull" + loggedAdmin.AccountName + loggedAdmin.Adress + loggedAdmin.Phone);
                            break;

                        case "Employee":
                            string employeeTableLine;
                            decimal earnings = 0;
                            using (StreamReader employeeInfo = new StreamReader("Employees.csv"))
                            {
                                employeeTableLine = employeeInfo.ReadLine();
                                string[] employeeCheck = employeeTableLine.Split(',');
                                while (employeeTableLine != null)
                                {
                                    if (employeeCheck[0] == accountCheck[0])
                                    {
                                        adress = employeeCheck[1];
                                        phone = employeeCheck[2];
                                        earnings = Convert.ToDecimal(employeeCheck[3]);
                                        break;
                                    }
                                }
                            }
                            EmployeeUser loggedEmployee = new EmployeeUser(accountCheck[0], accountCheck[1], AccountType.Employee, adress, phone, earnings);
                            MessageBox.Show("Log in successfull" + loggedEmployee.AccountName + loggedEmployee.Adress + loggedEmployee.Phone + loggedEmployee.Earnings.ToString());
                            break;
                        case "Client":
                            //see above
                            
                            
                            string clientTableLine;
                            using (StreamReader clientInfo = new StreamReader("Clients.csv"))
                            {
                                clientTableLine = clientInfo.ReadLine();
                                string [] clinetCheck = clientTableLine.Split(',');
                                while (clientTableLine!=null)
                                {
                                    if (clinetCheck[0] == accountCheck[0])
                                    {
                                        adress = clinetCheck[1];
                                        phone = clinetCheck[2];
                                        break;
                                    }
                                }
                            }
                            ClientUser loggedClient = new ClientUser (accountCheck[0], accountCheck[1], AccountType.Client,  adress,  phone);
                            MessageBox.Show("Log in successfull" + loggedClient.AccountName + loggedClient.Adress + loggedClient.Phone);
                            break;
                        default:
                            //again do we need that or do we use it as a third option (enumeration)
                            break;
                    }
                }//if end
                else
                {
                    MessageBox.Show("error");
                }
            }//using end
        }//method end

        abstract public void EditAccInfo(string accountName, string password, AccountType type);
    }
}

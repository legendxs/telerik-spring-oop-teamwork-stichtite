using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using StichtitePizzaForm.Interfaces;
using StichtitePizzaForm.CSVEditing;

namespace StichtitePizzaForm
{
    abstract class User : IUser 
    {
        public static void CreateAcc(string accountName, string password, AccountType type, string adress, string phone)
        {
            bool doesAccountExist = false;
            using (StreamReader checkExisting = new StreamReader("Accounts.csv"))
            {
                string checkExistingLine = checkExisting.ReadLine();
                string[] accountCheck = checkExistingLine.Split(',');
                while (checkExistingLine != null)
                {
                    accountCheck = checkExistingLine.Split(',');
                    if (accountCheck[0] == accountName)
                    {
                        doesAccountExist = true;
                        break;
                    }
                    checkExistingLine = checkExisting.ReadLine();
                }
            }
            if (doesAccountExist)
            {
                MessageBox.Show("Account with that name already exists. Please choose another");
            }
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
                        using (StreamWriter accountCreator = new StreamWriter("Accounts.csv",true))
                        {
                            accountCreator.WriteLine(accountInfo.ToString());
                        }
                        using (StreamWriter accountCreator = new StreamWriter("Admins.csv", true))
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
                            accountInfo.Append(accountName + "," + adress + "," + phone + "0");
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

        public static bool LogIn(string accountName, string password)
        {
            bool isLogInCorrect = false;
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
                        isLogInCorrect = true;
                        break;
                    }
                    accountTableLine = checkExisting.ReadLine();
                }

                if (isLogInCorrect)
                {
                    switch (accountCheck[2])
                    {
                        case "Admin":
                            //Creates an instance of the Admin class by reading the proper values for the properties from the table with the admin accounts

                            string adminTableLine;
                            using (StreamReader adminInfo = new StreamReader("Admins.csv"))
                            {
                                adminTableLine = adminInfo.ReadLine();
                                
                                while (adminTableLine != null)
                                {
                                    string[] adminCheck = adminTableLine.Split(',');
                                    if (adminCheck[0] == accountCheck[0])
                                    {
                                        adress = adminCheck[1];
                                        phone = adminCheck[2];
                                        AdminUser loggedAdmin = new AdminUser(accountCheck[0], accountCheck[1], AccountType.Admin, adress, phone);
                                        // Open xaml form here
                                        MessageBox.Show(String.Format("Log in successfull {0} {1} {2}", loggedAdmin.AccountName, loggedAdmin.Adress, loggedAdmin.Phone));
                                        break;
                                    }
                                    adminTableLine = adminInfo.ReadLine();
                                }
                            }
                            break;
                        case "Employee":
                            string employeeTableLine;
                            decimal earnings = 0;
                            using (StreamReader employeeInfo = new StreamReader("Employees.csv"))
                            {
                                employeeTableLine = employeeInfo.ReadLine();

                                while (employeeTableLine != null)
                                {
                                    string[] employeeCheck = employeeTableLine.Split(',');
                                    if (employeeCheck[0] == accountCheck[0])
                                    {
                                        adress = employeeCheck[1];
                                        phone = employeeCheck[2];
                                        earnings = Convert.ToDecimal(employeeCheck[3]);

                                        EmployeeUser loggedEmployee = new EmployeeUser(accountCheck[0], accountCheck[1], AccountType.Employee, adress, phone, earnings);
                                        // Open xaml form
                                        MessageBox.Show(String.Format("Log in successfull {0} {1} {2} {3}", loggedEmployee.AccountName, loggedEmployee.Adress, loggedEmployee.Phone, loggedEmployee.Earnings.ToString()));
                                        break;
                                    }
                                    employeeTableLine = employeeInfo.ReadLine();
                                }
                            }
                            break;
                        case "Client":
                            //see above
                            
                            string clientTableLine;
                            using (StreamReader clientInfo = new StreamReader("Clients.csv"))
                            {
                                clientTableLine = clientInfo.ReadLine();
                                
                                while (clientTableLine != null)
                                {
                                    string[] clinetCheck = clientTableLine.Split(',');
                                    if (clinetCheck[0] == accountCheck[0])
                                    {
                                        adress = clinetCheck[1];
                                        phone = clinetCheck[2];

                                        ClientUser loggedClient = new ClientUser(accountCheck[0], accountCheck[1], AccountType.Client, adress, phone);
                                        ClientWindowStart clientWindow = new ClientWindowStart();
                                        clientWindow.Show();
                                        break;
                                    }
                                    clientTableLine = clientInfo.ReadLine();
                                }
                            }
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
            return isLogInCorrect;
        }//method end

        abstract public void EditAccInfo(string accountName, string password, AccountType type);
    }
}
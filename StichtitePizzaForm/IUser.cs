using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StichtitePizzaForm
{
    interface IUser
    {
        //void LogIn(string accountName, string password);
        void EditAccInfo(string accountName, string password, AccountType type);
        //atributes will likly be changed
        // void CreateAcc(string accountName, string password, AccountType type, string adress, string phone);

        /*
         * summary:
         * this is not full implementation (hell its more of a markup then any implementation though some stuff is in)
         * the atributes for the methods come from the interface.
         * instances of the classes are created upon log in
         * creating accounts as well as editing them changes entries in the DB (csv, txt, w/e other files we use later on)
         */
    }
}

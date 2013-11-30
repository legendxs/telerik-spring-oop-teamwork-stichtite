using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StichtitePizzaForm.Interfaces
{
    interface ICsvInteract
    {
        void LineToArray();   
        void ArrayToLine(bool isAppend); //true means you append to the file, false you delete all of it first then write
    
    }
}

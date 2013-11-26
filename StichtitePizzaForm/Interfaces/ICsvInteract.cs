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
        string[] LineToArray(string[] holder, string filepath)
        {
            using(StreamReader csvReader= new StreamReader(filepath) )
            {
                if (csvReader.ReadLine() != null)
                {
                    holder = csvReader.ReadLine().Split(',');
                }
                else
                {
                    for (int i=0; i<holder.Length; i++)
                    {
                        holder[i] = "End of file";
                    }
                }
                return holder;
            }
        }
        //mind the lenght of the input array

        void ArrayToLine(string[] input, string filepath, bool isAppend) //true means you append to the file, false you delete all of it first then write
        {
            StringBuilder lineBuilder = new StringBuilder();
            for (int i=0; i<input.Length-1; i++)
            {
                lineBuilder.Append(input[i] + ",");
            }
            lineBuilder.Append(input[input.Length-1]);
            using (StreamWriter writeToCsv= new StreamWriter(filepath, isAppend))
            {
                writeToCsv.WriteLine(lineBuilder.ToString());
            }
        }
        
    }
}

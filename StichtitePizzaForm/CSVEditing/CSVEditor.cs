using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StichtitePizzaForm.Interfaces;
using System.IO;

namespace StichtitePizzaForm.CSVEditing
{
    class CSVEditor : ICsvInteract
    {
        string[] lineAsArray;  
        string filePath;
   
        public CSVEditor (string[] lineAsArray, string filePath)
        {
            this.LineAsArray = lineAsArray;
            this.FilePath = filePath;
        }

        public string[] LineAsArray
        {
            get
            {
                return this.lineAsArray;
            }
            set
            {
                this.lineAsArray=value;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        public void LineToArray()
        {
            using (StreamReader csvRead= new StreamReader(this.FilePath) )
            {
                this.LineAsArray = csvRead.ReadLine().Split(',');
            }           
        }

        public void ArrayToLine(bool isAppend)
        {
            using (StreamWriter csvWrite = new StreamWriter(this.FilePath, isAppend))
            {
                StringBuilder saveToCsv = new StringBuilder();
                for (int i=0; i<this.LineAsArray.Length-2; i++)
                {
                    saveToCsv.Append(this.LineAsArray[i] + ",");
                }
                saveToCsv.Append(this.LineAsArray[this.LineAsArray.Length - 1]);
                csvWrite.WriteLine(saveToCsv.ToString());
            }
        }
    }
}

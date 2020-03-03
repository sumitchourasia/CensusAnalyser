using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public IEnumerable<string> GetArray(string[] arr)
        {
            // Iterating array elements and returning  
            foreach (var element in arr)
            {
                yield return element.ToString(); // It returns elements after executing each iteration  
            }
        }
        public void LoadFile()
        {
            int count = 0;
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.SetDelimiters(new string[] { "," });
            while (!csvParser.EndOfData)
            {
                // Read current line fields, pointer moves to the next line.
                string[] fields = csvParser.ReadFields();
                IEnumerable<string> elements = GetArray(fields);
                foreach (var element in elements) // Iterating returned elements  
                {
                    Console.Write(element + "            ");
                    
                }
                count++;
                Console.WriteLine();
            }
            Console.WriteLine("count = "+count);
            csvParser.Close();
        }
    }
}

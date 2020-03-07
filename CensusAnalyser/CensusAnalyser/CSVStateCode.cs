using Microsoft.VisualBasic.FileIO;
using System;

namespace CensusAnalyser
{
    public class CSVStateCode
    {
        /// <summary>
        /// Loads the CSV state codes file
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string LoadCSVStateCodeFile(string path)
        {
            Console.WriteLine("csvstatecode");
            int count = 0;
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.SetDelimiters(new string[] { "," });
            while (!csvParser.EndOfData)
            {
                count++;
                csvParser.ReadFields();
            }
            return count.ToString();
        }
    }
}

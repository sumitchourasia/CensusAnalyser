using Microsoft.VisualBasic.FileIO;
using System;

namespace CensusAnalyser
{
    /// <summary>
    /// contains a method to load csv file
    /// </summary>
    public class CSVStateCensus
    {
        /// <summary>
        /// Loads the CSV state census file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public int LoadCSVStateCensusFile(string path)
        {
            int count = 0;
            TextFieldParser csvParser = new TextFieldParser(path);
            csvParser.SetDelimiters(new string[] { "," });
            while (!csvParser.EndOfData)
            {
                count++;
                csvParser.ReadFields();
            }
            return count;
        }
    }
}


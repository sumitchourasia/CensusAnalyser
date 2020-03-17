using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CensusAnalyser
{
    /// <summary>
    /// USCensus class 
    /// </summary>
    public class USCensus : ICensus
    {
        /// <summary>
        /// Path variable
        /// </summary>
        public string Path;

        /// <summary>
        /// Delimiter variable
        /// </summary>
        public string Delimiter;

        /// <summary>
        /// Header variable
        /// </summary>
        public string Header;

        public static Dictionary<int, USCensusDataDAO> USCensusDictionary = new Dictionary<int, USCensusDataDAO>();

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetPath(string path) { this.Path = path; }

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public void SetDelimiter(string Delimiter) { this.Delimiter = Delimiter; }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public void SetHeader(string Header) { this.Header = Header; }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        public string LoadCSVFile()
        {
            USCensusDataDAO node = null;
            int count = 0;
            try
            {
                if (!File.Exists(this.Path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(this.Path, "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                using (StreamReader sr = new StreamReader(Path))
                {
                    string element;
                    // Read and display lines from the file until the end of 
                    // the file is reached. 
                    while ((element = sr.ReadLine()) != null)
                    {
                        count++;
                        node = USCensusDataDAO.createNode(element);
                        if (node != null)
                            USCensusDictionary.Add(count, node);
                        else
                            count--;
                    }
                }
                return USCensusDictionary.Count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
    }
}

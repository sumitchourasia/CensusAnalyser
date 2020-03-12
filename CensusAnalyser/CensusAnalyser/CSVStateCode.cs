/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// CSVStateCode class
    /// </summary>
    public class CSVStateCode : Census
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCode"/> class.
        /// </summary>
        public CSVStateCode()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCode"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        public CSVStateCode(string path, string delimiter = null, string header = null) : base(path, delimiter, header)
        {

        }
        /// <summary>
        /// Gets the iterator.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns> iterator </returns>
        public IEnumerable<string> GetIterator(string path)
        {
            //// Iterating array elements and returning  
            foreach (string line in File.ReadLines(path))
            {
                yield return line; //// It returns elements after executing each iteration  
            }
        }

        /// <summary>
        /// Loads the CSV state census file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public override string LoadCSVFile()
        {
            int count = 0;
            try
            {
                if (!File.Exists(this.GetPath()))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(this.GetPath(), "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                IEnumerable<string> elements = GetIterator(this.GetPath());
                foreach (string element in elements)
                {
                    count++;
                    if (this.GetDelimiter() != null)
                    {
                        string[] arr = element.Split(this.GetDelimiter());
                        if (arr.Length < 2)
                            throw new CensusAnalyserException(Enum_Exception.Incorrect_Delimiter_Exception.ToString());
                    }
                    if (this.GetHeader() != null && count==1)
                        if (!element.Equals(this.GetHeader()))
                            throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
                    
                }
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
    }
}

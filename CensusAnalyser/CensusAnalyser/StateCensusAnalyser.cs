using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    /// <summary>
    /// contains method to load csv file and use iterator(IEnumerable)
    /// </summary>
    public class StateCensusAnalyser 
    {
        int count = 0;
        /// <summary>
        /// Gets the iterator.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetIterator(string path)
        {
                //// Iterating array elements and returning  
                foreach (string line in File.ReadLines(path))
                    yield return line; //// It returns elements after executing each iteration  
        }
        /// <summary>
        /// Load the states census file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string LoadstateCensusFile(string path)
        {
            try
            {
                Console.WriteLine(path);
                if (!File.Exists(path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(path, "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                IEnumerable<string> elements = StateCensusAnalyser.GetIterator(path);
                foreach (string element in elements)
                    count++;
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
        /// <summary>
        /// Load the states census file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string LoadstateCensusFile(string path,string delimiter)
        {
            try
            {
                if (!File.Exists(path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                IEnumerable<string> elements = StateCensusAnalyser.GetIterator(path);
                foreach (string element in elements)
                {
                    string[] arr = element.Split(delimiter);
                    if (arr.Length < 2)
                        throw new CensusAnalyserException(Enum_Exception.Incorrect_Delimiter_Exception.ToString());
                }
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
        /// <summary>
        /// Load the states census file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string LoadstateCensusFile(string path, string header1,string header2,string header3,string header4 )
        {
            try
            {
                if (!File.Exists(path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                IEnumerable<string> elements = StateCensusAnalyser.GetIterator(path);
                foreach (string element in elements)
                {
                    string[] arr = element.Split(",");
                    if (arr[0].Equals(header1) && arr[1].Equals(header2) && arr[2].Equals(header3) && arr[3].Equals(header4))
                        count++;
                    else
                        throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
                }
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
        /// <summary>
        /// Load the states code file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string LoadCSVstateCodesFile(string path)
        {
            count = 0;
            try
            {
                if (!File.Exists(path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                IEnumerable<string> elements = StateCensusAnalyser.GetIterator(path);
                foreach (string element in elements)
                    count++;
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
           
        }
    }
}

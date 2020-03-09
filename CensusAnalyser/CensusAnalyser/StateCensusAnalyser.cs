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
        public IEnumerable<string> GetIterator(string path)
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
        public string LoadCSVFile(string path, string Delimiter = null, string header = null)
        {
            try
            {
                if (!File.Exists(path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(path, "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                IEnumerable<string> elements = GetIterator(path);
                foreach (string element in elements)
                {
                    count++;
                    if (header != null)
                        if (!element.Equals(header))
                            throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
                    if (Delimiter != null)
                    {
                        string[] arr = element.Split(Delimiter);
                        if (arr.Length < 2)
                            throw new CensusAnalyserException(Enum_Exception.Incorrect_Delimiter_Exception.ToString());
                    }
                }
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
    }
    /// <summary>
    /// class to create delegate
    /// </summary>
    public class MyDelegate
    {
        public delegate String CSVStateDelegates(string path);
        public delegate String StateCensusAnalyserDelegates(string path, string delimiter = null, string header = null);
        /// <summary>
        /// create and returns delegate object
        /// </summary>
        /// <returns></returns>
        public static Delegate GetStateCensusAnalyserDelegate(int choice)
        {
            switch (choice) 
            {
                case 1:
                    StateCensusAnalyser statecensusobj = new StateCensusAnalyser();
                    StateCensusAnalyserDelegates delegateobject = new StateCensusAnalyserDelegates(statecensusobj.LoadCSVFile);
                    return delegateobject;
                case 2:
                    CSVStateCensus obj2 = new CSVStateCensus();
                    CSVStateDelegates delegateobject1 = new CSVStateDelegates(obj2.LoadCSVStateCensusFile);
                    return delegateobject1;
                case 3:
                    CSVStateCode obj3 = new CSVStateCode();
                    CSVStateDelegates delegateobject2 = new CSVStateDelegates(obj3.LoadCSVStateCodeFile);
                    return delegateobject2;
                default:
                    return null;
            }
        }
    }
}

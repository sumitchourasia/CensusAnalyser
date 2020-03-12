/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// contains method to load CSV file and use iterator(IEnumerable)
    /// </summary>
    public class StateCensusAnalyser : Census
    {
        /// <summary>
        /// count variable
        /// </summary>
        private int count = 0;
        private List<string> CensusList = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyser"/> class.
        /// </summary>
        public StateCensusAnalyser()
        {

        }

        /// <summary>
        /// constructor that may takes 3 paramter
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <param name="header"></param>
        public StateCensusAnalyser(string path, string delimiter = null, string header = null) : base(path, delimiter, header)
        {

        }

        /// <summary>
        /// Load the states census file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns> count of records </returns>
        public override string LoadCSVFile()
        {
            string record;
            TextFieldParser csvParser = new TextFieldParser(this.GetPath());
            csvParser.SetDelimiters( ",");
            while (!csvParser.EndOfData)
            {
                count++;
                record = csvParser.ReadLine();
                CensusList.Add(record);
            }
            foreach(var ele in CensusList)
            {
                Console.WriteLine(ele);
            }
            return count.ToString();
        }
    }

    /// <summary>
    /// class to create delegate
    /// </summary>
    public class MyDelegate
    {
        /// <summary>
        /// declare delgate
        /// </summary>
        /// <returns></returns>
        public delegate String CensusDelegates();

        /// <summary>
        /// declare delegate
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        /// <returns></returns>
        public delegate ICensus ConstructCensusUsingBuilder(string type, string Path, string Delimiter = null, string Header = null);

        public delegate void SerializeDelegate(ICensus censusObj);

        /// <summary>
        /// create and returns delegate object
        /// </summary>
        /// <returns> delgate object </returns>
        public static Delegate CreateCensusAnalyserDelegate(ICensus CensusObject)
        {
            CensusDelegates delegateobject = new CensusDelegates(CensusObject.LoadCSVFile);
            return delegateobject;
        }

        public static Delegate CreateSerializeDelegate(ICensus censusObj)
        {
            SerializeDelegate delegateobj = new SerializeDelegate(censusObj.Serialize);
            return delegateobj;
        }
    }
}

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
            TextFieldParser csvParser = new TextFieldParser(this.Path);
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
        private delegate ICensus ConstructCensusUsingBuilder(string type, string Path, string Delimiter = null, string Header = null);

        /// <summary>
        /// Delegate to serialize a object
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        public delegate void SerializeDelegate();

        /// <summary>
        /// create and returns delegate object
        /// </summary>
        /// <returns> delgate object </returns>
        public static Delegate CreateCensusAnalyserLoadFileDelegate(ICensus CensusObj)
        {
            CensusDelegates delegateobject = new CensusDelegates(CensusObj.LoadCSVFile);
            return delegateobject;
        }

        /// <summary>
        /// Constructs the census using builder.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        /// <returns></returns>
        public static Delegate CreateCensusLoadFileDelegateUsingBuilder(string type, string Path, string Delimiter = null, string Header = null)
        {
            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(Path);
            BuilderDirector.ConstructDelimiter(Delimiter);
            BuilderDirector.ConstructHeader(Header);
            ICensus _CensusObj = BuilderDirector.ConstructCensusUsingFactory(type);
            BuilderDirector.Construt(_CensusObj);
            Delegate CensusAnalyserDelegate = MyDelegate.CreateCensusAnalyserLoadFileDelegate(_CensusObj);
            return CensusAnalyserDelegate;
        }

        /// <summary>
        /// Creates the serialize delegate.
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        /// <returns></returns>
        public static Delegate CreateSerializeDelegate(ICensus censusObj)
        {
            SerializeDelegate delegateobj = new SerializeDelegate(censusObj.Serialize);
            return delegateobj;
        }
    }
}

/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// contains method to load CSV file and use iterator(IEnumerable)
    /// </summary>
    public class StateCensusAnalyser : CensusDAO
    {
        /// <summary>
        /// count variable
        /// </summary>
        private int count = 0; 

        /// <summary>
        /// The census code dictionary
        /// </summary>
        Dictionary<int, string> StateCensusAnalyserDictionary = new Dictionary<int, string>();

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
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns> count of records </returns>
        public override string LoadCSVFile()
        {
            string record;
            TextFieldParser csvParser = new TextFieldParser(this.Path);
            csvParser.SetDelimiters( ",");
            int RecordNo = 0;
            while (!csvParser.EndOfData)
            {
                count++;
                record = csvParser.ReadLine();
                if (count != 1)
                {
                    RecordNo = count - 1;
                    StateCensusAnalyserDictionary.Add(RecordNo, record);
                }
            }
            Console.WriteLine(" state census analyser : "+StateCensusAnalyserDictionary.Count);
            return StateCensusAnalyserDictionary.Count.ToString();
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
        private delegate ICensusDAO ConstructCensusUsingBuilder(string type, string Path, string Delimiter = null, string Header = null);

        /// <summary>
        /// Delegate to serialize a object
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        public delegate void SerializeDelegate(string path);

        /// <summary>
        /// create and returns delegate object
        /// </summary>
        /// <returns> delgate object </returns>
        public static Delegate CreateCensusAnalyserLoadFileDelegate(ICensusDAO CensusObj)
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
            ICensusDAO _CensusObj = BuilderDirector.ConstructCensusUsingFactory(type);
            BuilderDirector.Construt(_CensusObj);
            Delegate CensusAnalyserDelegate = MyDelegate.CreateCensusAnalyserLoadFileDelegate(_CensusObj);
            return CensusAnalyserDelegate;
        }

        /// <summary>
        /// Creates the serialize delegate.
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        /// <returns></returns>
        public static Delegate CreateSerializeDelegate(ICensusDAO censusObj)
        {
            SerializeDelegate delegateobj = new SerializeDelegate(censusObj.SerializeDictionary);
            return delegateobj;
        }
    }
}

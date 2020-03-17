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
    public class StateCensusAnalyser : IndianCensus
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
}

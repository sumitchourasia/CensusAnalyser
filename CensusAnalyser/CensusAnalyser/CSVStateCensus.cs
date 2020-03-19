/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    /// <summary>
    /// contains a method to load csv file 
    /// </summary>
    public class CSVStateCensus : IndianCensus
    {
        public static Dictionary<int, StateCensusDataDAO> CensusDataDictionary = new Dictionary<int, StateCensusDataDAO>();
        public static Dictionary<int, StateCensusDataDAO> CensusDataDictionaryMostPopulous = new Dictionary<int, StateCensusDataDAO>();
        public static Dictionary<int, StateCensusDataDAO> CensusDataDictionaryPopulationDensity = new Dictionary<int, StateCensusDataDAO>();
        public static Dictionary<int, StateCensusDataDAO> CensusDataDictionaryArea = new Dictionary<int, StateCensusDataDAO>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        public CSVStateCensus()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        public CSVStateCensus(string path, string delimiter = null, string header = null) : base(path, delimiter, header)
        {

        }

        /// <summary>
        /// Loads the CSV state census file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public override string LoadCSVFile()
        {
            StateCensusDataDAO node = null; 
            int count = 0; 
            try
            {
                if (!File.Exists(this.Path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(this.Path, "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                ////using stream
                using (StreamReader sr = new StreamReader(Path))
                {
                    string element;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((element = sr.ReadLine()) != null)
                    { 
                        count++;
                        CheckDelimiter(element);
                        CheckHeader(element);
                        node = StateCensusDataDAO.createNode(element);
                        if (node != null) 
                        {
                            CensusDataDictionary.Add(count, node);
                            CensusDataDictionaryMostPopulous.Add(count, node);
                            CensusDataDictionaryPopulationDensity.Add(count, node);
                            CensusDataDictionaryArea.Add(count,node);
                        }
                    }
                    sr.Close();
                }
                return CensusDataDictionary.Count.ToString(); 
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
    }
}


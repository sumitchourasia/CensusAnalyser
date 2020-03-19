/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    /// <summary>
    /// CSVStateCode class
    /// </summary>
    public class CSVStateCode : IndianCensus
    {
        public static Dictionary<int,StateCodeDataDAO> CensusCodeDictionary = new Dictionary<int,StateCodeDataDAO>();
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
        /// Loads the CSV state census file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public override string LoadCSVFile()
        {
            StateCodeDataDAO node = null;
            int count = 0;
            try 
            {
                if (!File.Exists(this.Path))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(this.Path , "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
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
                        node = StateCodeDataDAO.createNode(element);
                        if (node != null)
                            CensusCodeDictionary.Add(count, node);
                        else
                            count--;
                    }
                    sr.Close();
                }
                return CensusCodeDictionary.Count.ToString(); 
            }
            catch (CensusAnalyserException e) 
            {  
                return e.Msg; 
            } 
        }
    }
}

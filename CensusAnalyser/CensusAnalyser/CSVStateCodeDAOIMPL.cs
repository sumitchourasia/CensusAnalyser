/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// CSVStateCode class
    /// </summary>
    public class CSVStateCodeDAOIMPL : CensusDAO 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCodeDAOIMPL"/> class.
        /// </summary>
        public CSVStateCodeDAOIMPL()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCodeDAOIMPL"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        public CSVStateCodeDAOIMPL(string path, string delimiter = null, string header = null) : base(path, delimiter, header)
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
                foreach (string element in File.ReadLines(this.Path))
                {
                    count++; 
                    CheckDelimiter(element); 
                    CheckHeader(element); 
                    node = StateCodeDataDAO.createNode(element);
                    if (node != null)
                    {
                        int RecordNo = count-1;
                        CensusCodeDictionary.Add(RecordNo, node);
                    }
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

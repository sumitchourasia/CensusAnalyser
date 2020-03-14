/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
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
        /// Loads the CSV state census file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public override string LoadCSVFile()
        {
            ListNodeStateCode node = null;
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
                    node = ListNodeStateCode.createNode(element);
                    if(node != null)
                    CensusStateCodeList.Add(node);
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

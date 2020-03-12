﻿/// <summary>
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
    /// contains a method to load csv file
    /// </summary>
    public class CSVStateCensus : Census
    {
        private List<string> censusList = new List<string>();
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
            int count = 0;
            try
            {
                if (!File.Exists(this.GetPath()))
                    throw new CensusAnalyserException(Enum_Exception.No_Such_File_Exception.ToString());
                if (!Regex.IsMatch(this.GetPath(), "^[a-zA-Z][:][\a-zA-Z]+.csv$"))
                    throw new CensusAnalyserException(Enum_Exception.File_Type_MisMatch_Exception.ToString());
                foreach (string element in File.ReadLines(this.Path))
                {
                    count++;
                    CheckDelimiter(element);
                    CheckHeader(element);
                    censusList.Add(element);
                }
                PrintList(censusList);
                return count.ToString();
            }
            catch (CensusAnalyserException e)
            {
                return e.Msg;
            }
        }
    }
}


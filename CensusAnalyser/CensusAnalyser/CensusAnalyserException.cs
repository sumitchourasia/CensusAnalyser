/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// enum for Exceptions
    /// </summary>
    public enum Enum_Exception 
    {
       No_Such_File_Exception,
       File_Type_MisMatch_Exception,
       Incorrect_Delimiter_Exception,
       Incorrect_Header_Exception,
       NULL_CSVException
    }

    /// <summary>
    /// custom exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// Gets or sets the MSG.
        /// </summary>
        /// <value>
        /// The MSG.
        /// </value>
        public string Msg { get; set; }

        /// <summary>
        /// No-arg constructor
        /// </summary>
        public CensusAnalyserException() : base() { }

        /// <summary>
        /// parameterized constructor.
        /// </summary>
        /// <param name="Msg">The MSG.</param>
        public CensusAnalyserException(string Msg)
        {
            this.Msg = Msg;
        }
    }

    /// <summary>
    /// CSVBuilder exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CSVBuilderException : Exception
    {
        public string Msg { get; set; }

        public CSVBuilderException(string msg)
        {
            this.Msg = msg;
        }
    }

}

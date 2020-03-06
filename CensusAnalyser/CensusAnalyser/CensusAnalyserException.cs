using System;

namespace CensusAnalyser
{
    /// <summary>
    /// enum for Exceptions
    /// </summary>
    public enum Enum_Exception 
    {
       No_Such_File_Exception,
       File_Type_MisMatch_Exception,
       Incorrect_Delimiter_Exception,
       Incorrect_Header_Exception
    }

    /// <summary>
    /// custom exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CensusAnalyserException : Exception
    {
        public string Msg { get; set; }
        public CensusAnalyserException() : base()
        {

        }
        public CensusAnalyserException(string Msg)
        {
            this.Msg = Msg;
        }
    }
}

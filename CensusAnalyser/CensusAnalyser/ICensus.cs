
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CensusAnalyser 
{
    /// <summary>
    /// interface for census (for indian and US census)
    /// </summary>
    public interface ICensus
    {
        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        string LoadCSVFile();

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="Path">The path.</param>
        void SetPath(string Path);

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        void SetDelimiter(string Delimiter);

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        void SetHeader(string Header);
    }

    /// <summary>
    /// IndianCensus Abstract Class
    /// </summary>
    /// <seealso cref="CensusAnalyser.ICensus" />
    public abstract class IndianCensus : ICensus
    {
        /// <summary>
        /// Path variable
        /// </summary>
        protected string Path;

        /// <summary>
        /// Delimiter variable
        /// </summary>
        protected string Delimiter;

        /// <summary>
        /// Header variable
        /// </summary>
        protected string Header;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensus"/> class.
        /// </summary>
        public IndianCensus()
        {
           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensus"/> class.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        public IndianCensus(string Path,string Delimiter,string Header)
        {
            this.Path = Path;
            this.Delimiter = Delimiter;
            this.Header = Header;
        }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        public abstract string LoadCSVFile();

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetPath(string path) { this.Path = path; }

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public void SetDelimiter(string Delimiter) { this.Delimiter = Delimiter; }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public void SetHeader(string Header) { this.Header = Header; }

        /// <summary>
        /// Checks the delimiter. 
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CensusAnalyserException"></exception>
        protected bool CheckDelimiter(string element)
        {
            if (this.Delimiter != null)
            {
                string[] arr = element.Split(this.Delimiter);
                if (arr.Length < 2)
                    throw new CensusAnalyserException(Enum_Exception.Incorrect_Delimiter_Exception.ToString());
            }
            return true;
        }

        /// <summary>
        /// Checks the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CensusAnalyserException"></exception>
        protected bool CheckHeader(string element)
        {
            if (this.Header != null)
                if (!element.Equals(this.Header))
                    throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
            return true;
        }
    }
}

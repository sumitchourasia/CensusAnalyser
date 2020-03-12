
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Interface ICensus
    /// </summary>
    public interface ICensus
    {
        public string LoadCSVFile();
        
    }

    /// <summary>
    /// abstract class 
    /// </summary>
    /// <seealso cref="CensusAnalyser.ICensus" />
    public abstract class Census : ICensus
    {
        /// <summary>
        /// Path variable
        /// </summary>
        private string Path;
        /// <summary>
        /// Delimiter variable
        /// </summary>
        private string Delimiter;
        /// <summary>
        /// Header variable
        /// </summary>
        private string Header;

        /// <summary>
        /// Initializes a new instance of the <see cref="Census"/> class.
        /// </summary>
        public Census()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Census"/> class.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        public Census(string Path, string Delimiter, string Header)
        {
            this.Path = Path;
            this.Delimiter = Delimiter;
            this.Header = Header;
        }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns> count of record </returns>
        public abstract string LoadCSVFile();

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetPath(string path){ this.Path = path; }

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
        /// Gets the path.
        /// </summary>
        /// <returns></returns>
        public string GetPath() { return this.Path; }

        /// <summary>
        /// Gets the delimiter.
        /// </summary>
        /// <returns></returns>
        public string GetDelimiter() { return this.Delimiter; }

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <returns></returns>
        public string GetHeader() { return this.Header; }

    }
}

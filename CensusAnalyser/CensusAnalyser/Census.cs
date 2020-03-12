
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface ICensus
    /// </summary>
    public interface ICensus
    {
         string LoadCSVFile();

         public List<ListNode> GetList();

         void Serialize(ICensus censusObj);
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
        /// The census list
        /// </summary>
        protected List<ListNode> censusList = new List<ListNode>();

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

        public List<ListNode> GetList()
        {
            return censusList;
        }

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

        /// <summary>
        /// Checks the delimiter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CensusAnalyserException"></exception>
        protected bool CheckDelimiter(string element)
        {
            if (this.GetDelimiter() != null)
            {
                string[] arr = element.Split(this.GetDelimiter());
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
            if (this.GetHeader() != null)
                if (!element.Equals(this.GetHeader()))
                    throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
            return true;
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        protected void PrintList(List<string> list)
        {
            foreach(string element in list)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Serializes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Serialize(ICensus censusObj)
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string ListinString = JsonConvert.SerializeObject(censusList);
            File.WriteAllText(path ,ListinString);

            Console.WriteLine("list ref is : " + censusList);
            Console.WriteLine("serialized List");
            Console.WriteLine(ListinString);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        protected ListNode createNode(string element)
        {
            ListNode newnode;
            ListNode node=null;
            try
            {
                newnode = new ListNode();
                string[] arr = element.Split(",");
                newnode.StateName = arr[0];
                newnode.Population = Convert.ToInt32(arr[1]);
                if (arr[2] != null)
                    newnode.AreaInSqKm = Convert.ToInt32(arr[2]);
                if (arr[3] != null)
                    newnode.DensityPerSqKm = Convert.ToInt32(arr[3]);
                node = newnode;
            }
            catch(Exception e)
            {
                return node;
            }
            return node;
        }
    }
}

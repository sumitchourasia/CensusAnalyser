
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface ICensus
    /// </summary>
    public interface ICensus
    {
        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        string LoadCSVFile();

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="censusList">The census list.</param>
        void PrintList( ICensus censusObj);

        /// <summary>
        /// Sorts the list.
        /// </summary>
        void SortList();

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        void Serialize();
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

        /// <summary>
        /// Gets the census list.
        /// </summary>
        /// <returns></returns>
        public List<ListNode> GetCensusList()
        {
            return this.censusList;
        }

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

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(ICensus censusObj)
        {
            List<ListNode> list = ((Census)censusObj).censusList;
            foreach(ListNode element in list)
            {
                Console.Write(element.StateName + " ");
                Console.Write(element.Population + " ");
                Console.Write(element.AreaInSqKm + " ");
                Console.WriteLine(element.DensityPerSqKm + " ");
            }
        }

        /// <summary>
        /// Serializes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Serialize()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string ListinString = JsonConvert.SerializeObject(this.censusList);
            File.WriteAllText(path ,ListinString);
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void SortList()
        {
            censusList.Sort();
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            StreamReader streamReaderObject = new StreamReader(path);
            string jsonstring = streamReaderObject.ReadToEnd();
            return jsonstring;
        }

        /// <summary>
        /// Deserializes the specified jsonstring.
        /// </summary>
        /// <param name="jsonstring">The jsonstring.</param>
        /// <returns></returns>
        public static List<ListNode> Deserialize(string jsonstring)
        {
            List<ListNode> list = null;
            try
            {
                list = JsonConvert.DeserializeObject<List<ListNode>>(jsonstring);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        /// <summary>
        /// First and last item of json.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string FirstAndLastItemOfJson(string path)
        {
            List<ListNode> list = Deserialize(ReadFile(path));
            int length = 0;
            int count = list.Count ;
            string data=null;
            foreach(ListNode item in list)
            {
                if (length == 0 || length == count-1)
                    data += item.StateName;
                length++;
            }
            return data;
        }
    }
}

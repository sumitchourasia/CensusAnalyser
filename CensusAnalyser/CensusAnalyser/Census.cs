
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
        /// Prints the dictionary.
        /// </summary>
        void PrintDictionary();

        /// <summary>
        /// Sorts the dictionary.
        /// </summary>
        void SortDictionary();

        /// <summary>
        /// Serializes the dictionary.
        /// </summary>
        /// <param name="jsonpath">The jsonpath.</param>
        void SerializeDictionary(string jsonpath);
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
        /// The census code dictionary
        /// </summary>
        protected Dictionary<int , NodeStateCensusData> CensusDataDictionary = new Dictionary<int , NodeStateCensusData >();

        /// <summary>
        /// The census data dictionary
        /// </summary>
        protected Dictionary<int, NodeStateCodeData> CensusCodeDictionary = new Dictionary<int, NodeStateCodeData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Census"/> class.
        /// </summary>
        public Census()
        {

        }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns> count of record </returns>
        public abstract string LoadCSVFile();

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
        /// Prints the Dictionary.
        /// </summary>
        /// <param name="censusObj"> censusObj.</param>
        public void PrintDictionary()
        {
            Dictionary<int , NodeStateCensusData> DictionaryStateData;
            Dictionary<int , NodeStateCodeData> DictionaryStateCode;
            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensus"))
            {
                DictionaryStateData = ((Census)this).CensusDataDictionary;
                foreach (KeyValuePair<int,NodeStateCensusData> keyValue in DictionaryStateData) 
                {
                    NodeStateCensusData element = keyValue.Value;
                    Console.Write(element.StateName + " ");
                    Console.Write(element.Population + " ");
                    Console.Write(element.AreaInSqKm + " ");
                    Console.WriteLine(element.DensityPerSqKm + " ");
                }
            }
            else if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCode"))
            {
                DictionaryStateCode = ((Census)this).CensusCodeDictionary;
                foreach (KeyValuePair<int, NodeStateCodeData> keyValue in DictionaryStateCode)
                {
                    NodeStateCodeData element = keyValue.Value;
                    Console.Write(element.SerialNo + " ");
                    Console.Write(element.StateName + " ");
                    Console.Write(element.TIN + " ");
                    Console.Write(element.StateCode + " ");
                }
            }
        }

        /// <summary>
        /// Serializes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void SerializeDictionary(string jsonpath)
        {
            string DictionaryinString = null; 
            if (jsonpath.Contains("StateName"))
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionary);
            else if (jsonpath.Contains("StateCode"))
                DictionaryinString = JsonConvert.SerializeObject(this.CensusCodeDictionary);
            File.WriteAllText(jsonpath, DictionaryinString);
        }

        /// <summary>
        /// Sorts the dictionary.
        /// </summary>
        public void SortDictionary()
        {    /// <summary>
             /// The census code dictionary
             /// </summary>
            Dictionary<int, NodeStateCensusData> CensusDataDictionary2 = new Dictionary<int, NodeStateCensusData>();

             /// <summary>
             /// The census code dictionary
             /// </summary>
           Dictionary<int, NodeStateCodeData> CensusCodeDictionary2 = new Dictionary<int, NodeStateCodeData>();

           int count = 0;

            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensus"))
            {
                foreach (KeyValuePair<int, NodeStateCensusData> keyvalue in CensusDataDictionary.OrderBy(key => key.Value.StateName))
                {
                    count++;
                    CensusDataDictionary2.Add(count, keyvalue.Value);
                }
                CensusDataDictionary = CensusDataDictionary2;
            }
            else if(this.GetType().ToString().Equals("CensusAnalyser.CSVStateCode"))
            {
                count = 0;
                foreach (KeyValuePair<int, NodeStateCodeData> keyvalue in CensusCodeDictionary.OrderBy(key => key.Value.StateCode))
                {
                    count++;
                    CensusCodeDictionary2.Add(count, keyvalue.Value);
                }
                CensusCodeDictionary = CensusCodeDictionary2;
            }
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
        /// Deserializes the state code using Generics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonstring">The jsonstring.</param>
        /// <returns></returns>
        public static T DeserializeStateCodeGenerics<T>(string jsonstring)
        {
            dynamic dlist = null;
            try
            {
                dlist =(T)JsonConvert.DeserializeObject<T>(jsonstring);
                return dlist;
            }
            catch (Exception )
            {
                return dlist;
            }
        }

        /// <summary>
        ///  First and last item state code using generics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string FirstAndLastItemStateCodeGenerics<T>(string path)
        {
            T list = DeserializeStateCodeGenerics<T>(ReadFile(path));
            int length = 0;
            dynamic dlist = list;
            int count = dlist.Count;
            dynamic ddata = null;
            foreach ( dynamic item in dlist)
            {
                if (length == 0 || length == count - 1)
                    ddata += item.Value.StateName;
                length++;
            }
            return ddata;
        }
    }
}

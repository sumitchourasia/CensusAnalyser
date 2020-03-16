
/// <summary>
/// namespace CensusAnalyser
/// </summary>
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
    public interface ICensusDAO
    {
        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        string LoadCSVFile();

        /// <summary>
        /// Prints the dictionary.
        /// </summary>
        void PrintDictionary(string SortBasedOn="StateName");

        /// <summary>
        /// Sorts the dictionary.
        /// </summary>
        void SortDictionary();

        /// <summary>
        /// Sorts the dictionary most populous.
        /// </summary>
        int SortDictionaryMostPopulous();

        /// <summary>
        /// Sorts the dictionary population density.
        /// </summary>
        void SortDictionaryPopulationDensity();

        /// <summary>
        /// Sorts the dictionary in descending order.
        /// </summary>
        void SortDictionaryMostArea();

        /// <summary>
        /// Serializes the dictionary.
        /// </summary>
        /// <param name="jsonpath">The jsonpath.</param>
        void SerializeDictionary(string jsonpath);

        /// <summary>
        /// First and last item state code using generics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        string FirstAndLastItemStateCodeGenerics<T>(string path);
    }

    /// <summary>
    /// abstract class 
    /// </summary>
    /// <seealso cref="CensusAnalyser.ICensusDAO" />
    public abstract class CensusDAO : ICensusDAO
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
        protected Dictionary<int , StateCensusDataDAO> CensusDataDictionary = new Dictionary<int , StateCensusDataDAO>();

        /// <summary>
        /// The census data dictionary 
        /// </summary>
        protected Dictionary<int, StateCodeDataDAO> CensusCodeDictionary = new Dictionary<int, StateCodeDataDAO>();

        /// <summary>
        /// The census code dictionary
        /// </summary>
        protected Dictionary<int, StateCensusDataDAO> CensusDataDictionaryMostPopulous = new Dictionary<int, StateCensusDataDAO>();

        /// <summary>
        /// The census code dictionary
        /// </summary>
        protected Dictionary<int, StateCensusDataDAO> CensusDataDictionaryPopulationDensity = new Dictionary<int, StateCensusDataDAO>();

        /// <summary>
        /// The census code dictionary
        /// </summary>
        protected Dictionary<int, StateCensusDataDAO> CensusDataDictionaryArea = new Dictionary<int, StateCensusDataDAO>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        public CensusDAO()
        {

        }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns> count of record </returns>
        public abstract string LoadCSVFile();

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        public CensusDAO(string Path, string Delimiter, string Header)
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
        public void PrintDictionary(String SortbasedOn="StateName")
        {
            Dictionary<int , StateCensusDataDAO> DictionaryStateData;
            Dictionary<int , StateCodeDataDAO> DictionaryStateCode;
            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensusDAOIMPL"))
            {
                if (SortbasedOn.Equals("StateName"))
                {
                    DictionaryStateData = ((CensusDAO)this).CensusDataDictionary;
                    foreach (KeyValuePair<int, StateCensusDataDAO> keyValue in CensusDataDictionary)
                    {
                        StateCensusDataDAO element = keyValue.Value;
                        Console.WriteLine("key : " + keyValue.Key);
                        Console.WriteLine("Value : ");
                        Console.WriteLine("\tStateName : " + element.StateName);
                        Console.WriteLine("\tPopulation : " + element.Population);
                        Console.WriteLine("\tAreaInSqKm : " + element.AreaInSqKm);
                        Console.WriteLine("\tDensityPerSqKm : " + element.DensityPerSqKm + " ");
                    }
                }
                else if (SortbasedOn.Equals("Population"))
                {
                    DictionaryStateData = ((CensusDAO)this).CensusDataDictionaryMostPopulous;
                    foreach (KeyValuePair<int, StateCensusDataDAO> keyValue in CensusDataDictionaryMostPopulous)
                    {
                        StateCensusDataDAO element = keyValue.Value;
                        Console.WriteLine("key : " + keyValue.Key);
                        Console.WriteLine("Value : ");
                        Console.WriteLine("\tStateName : " + element.StateName);
                        Console.WriteLine("\tPopulation : " + element.Population);
                        Console.WriteLine("\tAreaInSqKm : " + element.AreaInSqKm);
                        Console.WriteLine("\tDensityPerSqKm : " + element.DensityPerSqKm + " ");
                    }
                }
            }
            else if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCodeDAOIMPL"))
            {
                DictionaryStateCode = ((CensusDAO)this).CensusCodeDictionary;
                foreach (KeyValuePair<int, StateCodeDataDAO> keyValue in DictionaryStateCode)
                {
                    StateCodeDataDAO element = keyValue.Value;
                    Console.WriteLine("key : " + keyValue.Key);
                    Console.WriteLine("Value : ");
                    Console.WriteLine("\tSerialNo :  " + element.SerialNo);
                    Console.WriteLine("\tStateName : " + element.StateName);
                    Console.WriteLine("\tIN :       " + element.TIN);
                    Console.WriteLine("\tStateCode : " + element.StateCode);
                }
            }
        }

        /// <summary>
        /// Sorts the dictionary.
        /// </summary>
        public void SortDictionary()
        {    /// <summary>
             /// The census code dictionary
             /// </summary>
           Dictionary<int, StateCensusDataDAO> CensusDataDictionary2 = new Dictionary<int, StateCensusDataDAO>();

             /// <summary>
             /// The census code dictionary
             /// </summary>
           Dictionary<int, StateCodeDataDAO> CensusCodeDictionary2 = new Dictionary<int, StateCodeDataDAO>();

           int count = 0;

            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensusDAOIMPL")) 
            {
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalue in CensusDataDictionary.OrderBy(key => key.Value.StateName))
                {
                    count++;
                    CensusDataDictionary2.Add(count, keyvalue.Value);
                }
                CensusDataDictionary = CensusDataDictionary2;
            }
            else if(this.GetType().ToString().Equals("CensusAnalyser.CSVStateCodeDAOIMPL"))
            {
                count = 0;
                foreach (KeyValuePair<int, StateCodeDataDAO> keyvalue in CensusCodeDictionary.OrderBy(key => key.Value.StateCode))
                {
                    count++;
                    CensusCodeDictionary2.Add(count, keyvalue.Value);
                }
                CensusCodeDictionary = CensusCodeDictionary2;
            }
        }

        /// <summary>
        /// Sorts the dictionary based on decensding order of population.
        /// </summary>
        public int SortDictionaryMostPopulous() 
        {
            /// <summary>
            /// The census code dictionary
            /// </summary>
            Dictionary<int, StateCensusDataDAO> CensusDataDictionaryMostPopulous2 = new Dictionary<int, StateCensusDataDAO>();
            int count = 0; 
            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensusDAOIMPL"))
            {
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalue in CensusDataDictionaryMostPopulous.OrderByDescending(key => key.Value.Population))
                {
                    count++; 
                    CensusDataDictionaryMostPopulous2.Add(count, keyvalue.Value); 
                }
                CensusDataDictionaryMostPopulous = CensusDataDictionaryMostPopulous2; 
            }
            return count;
        }

        /// <summary>
        /// Sorts the dictionary based on population density.
        /// </summary>
        /// <returns></returns>
        public void SortDictionaryPopulationDensity()
        {
            /// <summary>
            /// The census code dictionary
            /// </summary>
            Dictionary<int, StateCensusDataDAO> CensusDataDictionaryPopulationDensity2 = new Dictionary<int, StateCensusDataDAO>();

            int count = 0;
            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensusDAOIMPL"))
            {
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalue in CensusDataDictionaryMostPopulous.OrderByDescending(key => key.Value.DensityPerSqKm))
                {
                    count++;
                    CensusDataDictionaryPopulationDensity2.Add(count, keyvalue.Value);
                }
                CensusDataDictionaryPopulationDensity = CensusDataDictionaryPopulationDensity2;
            }
        }

        /// <summary>
        /// Sorts the dictionary in descending order.
        /// </summary>
        public void SortDictionaryMostArea()
        {
            /// <summary>
            /// The census code dictionary
            /// </summary>
            Dictionary<int, StateCensusDataDAO> CensusDataDictionaryArea2 = new Dictionary<int, StateCensusDataDAO>();

            int count = 0;
            if (this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensusDAOIMPL"))
            {
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalue in CensusDataDictionaryArea.OrderByDescending(key => key.Value.AreaInSqKm))
                {
                    count++;
                    CensusDataDictionaryArea2.Add(count, keyvalue.Value);
                }
                CensusDataDictionaryArea = CensusDataDictionaryArea2;
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
            else if (jsonpath.Contains("MostPopulous"))
            {
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryMostPopulous);
            }
            else if (jsonpath.Contains("PopulationDensity"))
            {
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryPopulationDensity);
            }
            else if (jsonpath.Contains("MostArea"))
            {
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryArea);
            }
            File.WriteAllText(jsonpath, DictionaryinString);
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
        public string FirstAndLastItemStateCodeGenerics<T>(string path)
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


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
        /// Prints the dictionary.
        /// </summary>
        void PrintDictionary(ICensus censusObj, string SortBasedOn="StateName");

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
    public class CensusDAO : ICensusDAO
    {
        ICensus censusObj = null;

        public static Dictionary<int, StateCensusDataDAO> CensusDataDictionarysorted = null;

        public static Dictionary<int, StateCodeDataDAO> CensusCodeDictionarysorted = null;

        /// <summary>
        /// The census code dictionary 
        /// </summary>
         Dictionary<int , StateCensusDataDAO> CensusDataDictionary = CSVStateCensus.CensusDataDictionary;

        /// <summary>
        /// The census data dictionary 
        /// </summary>
         Dictionary<int, StateCodeDataDAO> CensusCodeDictionary = CSVStateCode.CensusCodeDictionary;

        /// <summary>
        /// The census code dictionary 
        /// </summary>
         Dictionary<int, StateCensusDataDAO> CensusDataDictionaryMostPopulous = CSVStateCensus.CensusDataDictionaryMostPopulous;

        /// <summary>
        /// The census code dictionary
        /// </summary>
         Dictionary<int, StateCensusDataDAO> CensusDataDictionaryPopulationDensity = CSVStateCensus.CensusDataDictionaryPopulationDensity;

        /// <summary>
        /// The census code dictionary
        /// </summary>
         Dictionary<int, StateCensusDataDAO> CensusDataDictionaryArea = CSVStateCensus.CensusDataDictionaryArea;

        Dictionary<int, USCensusDataDAO> USCensusDictionary = USCensus.USCensusDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        public CensusDAO(ICensus censusObj)
        {
            this.censusObj = censusObj;
        }

        /// <summary>
        /// Prints the Dictionary.
        /// </summary>
        /// <param name="censusObj"> censusObj.</param>
        public void PrintDictionary(ICensus censusObj ,String SortbasedOn="StateName")
        {
            Dictionary<int , StateCensusDataDAO> DictionaryStateData;
            Dictionary<int , StateCodeDataDAO> DictionaryStateCode;
            Dictionary<int, USCensusDataDAO> DictionaryUSCensus;
            if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower()))
            {
                    if (SortbasedOn.Equals("StateName"))
                        DictionaryStateData = CensusDataDictionary;
                    else if (SortbasedOn.Equals("Population"))
                        DictionaryStateData = CensusDataDictionaryMostPopulous;
                    else if (SortbasedOn.Equals("Density"))
                        DictionaryStateData =CensusDataDictionaryPopulationDensity;
                    else if (SortbasedOn.Equals("Area"))
                        DictionaryStateData = CensusDataDictionaryArea;
                    else
                        DictionaryStateData = null;
                    foreach (KeyValuePair<int, StateCensusDataDAO> keyValue in DictionaryStateData)
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
            else if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCode".ToLower()))
            {
                DictionaryStateCode = CensusCodeDictionary;
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
            else if ( censusObj.GetType().ToString().Equals("CensusAnalyser.USCensus"))
            {
                DictionaryUSCensus = USCensusDictionary;
                foreach (KeyValuePair<int, USCensusDataDAO> keyValue in DictionaryUSCensus)
                {
                    USCensusDataDAO element = keyValue.Value;
                    Console.WriteLine("key : " + keyValue.Key);
                    Console.WriteLine("Value : ");
                    Console.WriteLine("\tStateId :  " + element.StateId);
                    Console.WriteLine("\tStateName : " + element.State);
                    Console.WriteLine("\tPopulation : " + element.Population);
                    Console.WriteLine("\tHousingUnits : " + element.HousingUnits);
                    Console.WriteLine("\tTotalArea :  " + element.TotalArea);
                    Console.WriteLine("\tWaterArea : " + element.WaterArea);
                    Console.WriteLine("\tLandArea : " + element.LandArea);
                    Console.WriteLine("\tPopulationDensity : " + element.PopulationDensity);
                    Console.WriteLine("\tHousingDensity : " + element.HousingDensity);
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

            if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower())) 
            {
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalue in CensusDataDictionary.OrderBy(key => key.Value.StateName))
                {
                    count++;
                    CensusDataDictionary2.Add(count, keyvalue.Value);
                }
                CensusDataDictionary = CensusDataDictionary2;
                CensusDataDictionarysorted = CensusDataDictionary2;
            }
            else if(censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCode".ToLower()))
            {
                count = 0;
                foreach (KeyValuePair<int, StateCodeDataDAO> keyvalue in CensusCodeDictionary.OrderBy(key => key.Value.StateCode))
                {
                    count++;
                    CensusCodeDictionary2.Add(count, keyvalue.Value);
                }
                CensusCodeDictionary = CensusCodeDictionary2;
                CensusCodeDictionarysorted = CensusCodeDictionary2;
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
            if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower()))
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
            if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower()))
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
            if (censusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower())) 
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
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryMostPopulous);
            else if (jsonpath.Contains("PopulationDensity"))
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryPopulationDensity);
            else if (jsonpath.Contains("MostArea"))
                DictionaryinString = JsonConvert.SerializeObject(this.CensusDataDictionaryArea);
            else if (jsonpath.Contains("Merged"))
                DictionaryinString = JsonConvert.SerializeObject(AdaptorIndianCensusImpl.IndianCensusMergedDictionary);
            else
                DictionaryinString = null;
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

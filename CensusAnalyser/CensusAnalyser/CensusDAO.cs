
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
        /// Creates the indian census.
        /// </summary>
        /// <returns>  Dictionary<int, IndianCensusCSVDTO></returns>
        Dictionary<int, IndianCensusCSVDTO> CreateIndianCensus();

        /// <summary>
        /// Prints the dictionary.
        /// </summary>
        void PrintDictionary(ICensus censusObj, string SortBasedOn="StateName");

        /// <summary>
        /// Sorts the dictionary.
        /// </summary>
        int SortDictionary( ICensus CensusObj , String SortBasedOn="StateName");

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

        /// <summary>
        /// IndianCensusDictionary 
        /// </summary>
        public static Dictionary<int, IndianCensusCSVDTO> IndianCensusDictionary = new Dictionary<int, IndianCensusCSVDTO>();

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
        public void PrintDictionary(ICensus CensusObj ,String SortbasedOn="StateName")
        { 
            Dictionary<int , StateCensusAdapterDTO> DictionaryStateData;
            Dictionary<int , StateCodeAdapterDTO> DictionaryStateCode;

            if (CensusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower()))
            {
                DictionaryStateData = AdaptorIndianCensusImpl.StateCensusAdapterDictionary;
               
                foreach (KeyValuePair<int, StateCensusAdapterDTO> keyValue in DictionaryStateData)
                {
                    StateCensusAdapterDTO element = keyValue.Value;
                    Console.WriteLine("key : " + keyValue.Key);
                    Console.WriteLine("Value : ");
                    Console.WriteLine("\tStateName : " + element.GetStateName());
                    Console.WriteLine("\tPopulation : " + element.GetPopulation());
                    Console.WriteLine("\tAreaInSqKm : " + element.GetArea());
                    Console.WriteLine("\tDensityPerSqKm : " + element.GetDensity());
                }
            }
            else if (CensusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCode".ToLower()))
            {
                DictionaryStateCode = AdaptorIndianCensusImpl.StateCodeAdaptorDictionary;
                foreach (KeyValuePair<int, StateCodeAdapterDTO> keyValue in DictionaryStateCode)
                {
                    StateCodeAdapterDTO element = keyValue.Value;
                    Console.WriteLine("key : " + keyValue.Key);
                    Console.WriteLine("Value : ");
                    Console.WriteLine("\tSerialNo :  " + element.GetSerialNumber());
                    Console.WriteLine("\tStateName : " + element.GetStateName());
                    Console.WriteLine("\tIN :       " + element.GetTIN());
                    Console.WriteLine("\tStateCode : " + element.GetStateCode()); 
                }
            }
            else if (CensusObj.GetType().ToString().Equals("CensusAnalyser.USCensus"))
            {
                foreach (KeyValuePair<int, USCensusAdapterDTO> keyValue in USCensusAdapterIMPL.USCensusAdapterDictionary)
                {
                    USCensusAdapterDTO element = keyValue.Value;
                    Console.WriteLine("key : " + keyValue.Key);
                    Console.WriteLine("Value : ");
                    Console.WriteLine("\tStateId :  " + element.GetStateCode());
                    Console.WriteLine("\tStateName : " + element.GetStateName());
                    Console.WriteLine("\tPopulation : " + element.GetPopulation());
                    Console.WriteLine("\tHousingUnits : " + element.GetHousingUnit());
                    Console.WriteLine("\tTotalArea :  " + element.GetTotalArea());
                    Console.WriteLine("\tWaterArea : " + element.GetWaterArea());
                    Console.WriteLine("\tLandArea : " + element.GetLandArea());
                    Console.WriteLine("\tPopulationDensity : " + element.GetPopulationDensity());
                    Console.WriteLine("\tHousingDensity : " + element.GetHousingDensity());
                }
            }
        }

        /// <summary> 
        /// Sorts the dictionary. 
        /// </summary>
        public int SortDictionary(ICensus CensusObj, string SortBasedOn="StateName")
        {    /// <summary>
             /// The census code dictionary
             /// </summary>
           Dictionary<int, StateCensusAdapterDTO> CensusDataDictionaryTemp = new Dictionary<int, StateCensusAdapterDTO>();

           int count = 0;   

            if (CensusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCensus".ToLower())) 
            {
                ////begining of switch
                switch (SortBasedOn)
                {
                    case "StateName":
                            foreach (KeyValuePair<int, StateCensusAdapterDTO> keyvalue in AdaptorIndianCensusImpl.StateCensusAdapterDictionary.OrderBy(key => key.Value.GetStateName()))
                            {
                                count++;
                                CensusDataDictionaryTemp.Add(count, keyvalue.Value);
                            }
                            AdaptorIndianCensusImpl.StateCensusAdapterDictionary = CensusDataDictionaryTemp;
                            return AdaptorIndianCensusImpl.StateCensusAdapterDictionary.Count;
                    case "Population":
                            count = 0;
                            foreach (KeyValuePair<int, StateCensusAdapterDTO> keyvalue in AdaptorIndianCensusImpl.StateCensusAdapterDictionary.OrderByDescending(key => key.Value.GetPopulation()))
                            {
                                count++;
                                CensusDataDictionaryTemp.Add(count, keyvalue.Value);
                            }
                            AdaptorIndianCensusImpl.StateCensusAdapterDictionary = CensusDataDictionaryTemp;
                            return AdaptorIndianCensusImpl.StateCensusAdapterDictionary.Count;
                    case "Density":
                            count = 0;
                            foreach (KeyValuePair<int, StateCensusAdapterDTO> keyvalue in AdaptorIndianCensusImpl.StateCensusAdapterDictionary.OrderByDescending(key => key.Value.GetDensity()))
                            {
                                CensusDataDictionaryTemp.Add(++count, keyvalue.Value);
                            }
                            AdaptorIndianCensusImpl.StateCensusAdapterDictionary = CensusDataDictionaryTemp;
                            return AdaptorIndianCensusImpl.StateCensusAdapterDictionary.Count;
                    case  "Area":
                            count = 0;
                            foreach (KeyValuePair<int, StateCensusAdapterDTO> keyvalue in AdaptorIndianCensusImpl.StateCensusAdapterDictionary.OrderByDescending(key => key.Value.GetArea()))
                            {
                                count++;
                                CensusDataDictionaryTemp.Add(count, keyvalue.Value);
                            }
                            AdaptorIndianCensusImpl.StateCensusAdapterDictionary = CensusDataDictionaryTemp;
                            return AdaptorIndianCensusImpl.StateCensusAdapterDictionary.Count;
                }
                //end of switch
            }
            else if (CensusObj.GetType().ToString().ToLower().Equals("CensusAnalyser.CSVStateCode".ToLower()))
            {
                count = 0;
                /// <summary>
                /// The census code dictionary
                /// </summary>
                Dictionary<int, StateCodeAdapterDTO> CensusCodeDictionaryTemp = new Dictionary<int, StateCodeAdapterDTO>();
                foreach (KeyValuePair<int, StateCodeAdapterDTO> keyvalue in AdaptorIndianCensusImpl.StateCodeAdaptorDictionary.OrderBy(key => key.Value.GetStateCode()))
                {
                    count++;
                    CensusCodeDictionaryTemp.Add(count, keyvalue.Value);
                }
                AdaptorIndianCensusImpl.StateCodeAdaptorDictionary = CensusCodeDictionaryTemp;
                return AdaptorIndianCensusImpl.StateCodeAdaptorDictionary.Count;
            }
            else if (CensusObj.GetType().ToString().Equals("CensusAnalyser.USCensus"))
            {
                count = 0;
                /// <summary>
                /// The us census adapter dictionary2
                /// </summary>
                Dictionary<int, USCensusAdapterDTO> USCensusAdapterDictionarytemp = new Dictionary<int, USCensusAdapterDTO>();
                
                foreach (KeyValuePair<int, USCensusAdapterDTO> keyvalueUS in USCensusAdapterIMPL.USCensusAdapterDictionary.OrderByDescending(key => key.Value.GetPopulation()))
                {
                    USCensusAdapterDictionarytemp.Add(++count, keyvalueUS.Value);
                }
                USCensusAdapterIMPL.USCensusAdapterDictionary = USCensusAdapterDictionarytemp;
                return USCensusAdapterIMPL.USCensusAdapterDictionary.Count;
            }
            return 0;
        }

        /// <summary>
        /// Serializes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void SerializeDictionary(string jsonpath)
        {
            string DictionaryinString = null;

            if (jsonpath.Contains("StateName") || jsonpath.Contains("MostPopulous") || jsonpath.Contains("PopulationDensity") || jsonpath.Contains("MostArea"))
                DictionaryinString = JsonConvert.SerializeObject(AdaptorIndianCensusImpl.StateCensusAdapterDictionary);
            else if (jsonpath.Contains("StateCode"))
                DictionaryinString = JsonConvert.SerializeObject(AdaptorIndianCensusImpl.StateCodeAdaptorDictionary);
            else if(jsonpath.Contains("Merged"))
                DictionaryinString = JsonConvert.SerializeObject(IndianCensusDictionary);
            else if (jsonpath.Contains("USCensusPopulation"))
                DictionaryinString = JsonConvert.SerializeObject(USCensusAdapterIMPL.USCensusAdapterDictionary);
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

        /// <summary>
        /// Method to covert india census data so as to be able to be operated upon by CensusDAO
        /// </summary>
        /// <returns> Dictionary<int, MergedIndianCensusDataModalDao></returns>
        public Dictionary<int, IndianCensusCSVDTO> CreateIndianCensus() 
        {
            bool flag = false;
            IndianCensusCSVDTO newnode = null;
            Dictionary<int, StateCensusAdapterDTO> stateCensusData = AdaptorIndianCensusImpl.StateCensusAdapterDictionary;
            Dictionary<int, StateCodeAdapterDTO> stateCodeData = AdaptorIndianCensusImpl.StateCodeAdaptorDictionary;
            int count = 0; 
            foreach (KeyValuePair<int,StateCodeAdapterDTO> keyvalueCode in stateCodeData)
            {
                flag = false;
                foreach (KeyValuePair<int, StateCensusAdapterDTO> keyandvalueState in stateCensusData)
                {
                    if (keyandvalueState.Value.GetStateName().Equals(keyvalueCode.Value.StateName))
                    {
                        newnode = IndianCensusCSVDTO.createNode(keyandvalueState.Value, keyvalueCode.Value);
                        //Console.WriteLine(++count + " - " + newnode.StateName);
                        IndianCensusDictionary.Add(++count, newnode);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    newnode = IndianCensusCSVDTO.createNode(null, keyvalueCode.Value);
                    // Console.WriteLine(++count + " - " + newnode.StateName);
                    IndianCensusDictionary.Add(++count, newnode);
                }
            }
            foreach (KeyValuePair<int, IndianCensusCSVDTO> keyandvalue in IndianCensusDictionary)
            {
                Console.WriteLine(keyandvalue.Value.StateName); 
            }
            return IndianCensusDictionary;
        }
    }
}

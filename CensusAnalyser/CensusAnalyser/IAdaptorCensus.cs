using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    /// <summary>
    /// IAdaptorCensus       
    /// </summary>
    public interface IAdaptorCensus
    {
        Dictionary<int, MergedIndianCensusDataModalDao> ConvertIndianCensus();
        Dictionary<int, USCensusDataDAO> ConvertUSCensus();
      //  void ConvertUSCensus();
    }

    /// <summary>
    /// AdaptorIndianCensusImpl class 
    /// </summary>
    /// <seealso cref="CensusAnalyser.IAdaptorCensus" />
    public class AdaptorIndianCensusImpl : IAdaptorCensus
    {

        public static Dictionary<int, MergedIndianCensusDataModalDao> IndianCensusMergedDictionary = new Dictionary<int, MergedIndianCensusDataModalDao>();

        /// <summary>
        /// No-Arg Constructor
        /// </summary>
        public AdaptorIndianCensusImpl()
        {
        }

        /// <summary>
        /// Method to covert india census data so as to be able to be operated upon by CensusDAO
        /// </summary>
        /// <returns> Dictionary<int, MergedIndianCensusDataModalDao></returns>
        public Dictionary<int, MergedIndianCensusDataModalDao> ConvertIndianCensus()
        {
            bool flag = false;
            MergedIndianCensusDataModalDao newnode = null;
            Dictionary<int, StateCodeDataDAO> stateCodeData = CensusDAO.CensusCodeDictionarysorted ;
            Dictionary<int, StateCensusDataDAO> stateCensusData = CensusDAO.CensusDataDictionarysorted;
            int count = 0;
                foreach (var keyvalueCode in stateCodeData)
                {
                    flag = false;
                        foreach (KeyValuePair<int, StateCensusDataDAO> keyandvalueState in stateCensusData)
                        {
                            if (keyandvalueState.Value.StateName.Equals(keyvalueCode.Value.StateName))
                            {
                                newnode = MergedIndianCensusDataModalDao.createNode(keyandvalueState.Value, keyvalueCode.Value);
                            //Console.WriteLine(++count + " - " + newnode.StateName);
                            IndianCensusMergedDictionary.Add(++count, newnode);
                                flag = true;
                                break;
                            }
                        }
                    if (flag==false)
                    {
                        newnode = MergedIndianCensusDataModalDao.createNode(null, keyvalueCode.Value);
                        // Console.WriteLine(++count + " - " + newnode.StateName);
                        IndianCensusMergedDictionary.Add(++count, newnode);
                    }
                }
                foreach(KeyValuePair<int,MergedIndianCensusDataModalDao> keyandvalue in IndianCensusMergedDictionary)
                {
                    Console.WriteLine(keyandvalue.Value.StateName);
                }
            return IndianCensusMergedDictionary;
        }


        /// <summary>
        /// unimplemented method
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, USCensusDataDAO> ConvertUSCensus()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// method to convert the USCensus data to readable form by CensusDAO
    /// </summary>
    public class USCensusAdapter : IAdaptorCensus
    {
        public static Dictionary<int, USCensusDataDAO> USCensusAdapterDictionary = USCensus.USCensusDictionary;

        /// <summary>
        /// unimplemeted method
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, MergedIndianCensusDataModalDao> ConvertIndianCensus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// convert USCensus Data 
        /// </summary>
        /// <returns>Dictionary<int, USCensusDataDAO></returns>
        public Dictionary<int, USCensusDataDAO> ConvertUSCensus()
        {
            return USCensusAdapterDictionary;
        }
    }
}

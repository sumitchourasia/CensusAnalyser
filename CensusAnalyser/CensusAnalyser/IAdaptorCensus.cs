using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    /// <summary>
    /// IAdaptorCensus       
    /// </summary>
    public interface IAdaptorCensus
    {
        void ConvertCensus();
    }

    /// <summary>
    /// AdaptorIndianCensusImpl class 
    /// </summary>
    /// <seealso cref="CensusAnalyser.IAdaptorCensus" />
    public class AdaptorIndianCensusImpl : IAdaptorCensus
    {
        private ICensus CensusObj;
        public static Dictionary<int, StateCensusAdapterDTO> StateCensusAdapterDictionary = new Dictionary<int, StateCensusAdapterDTO>();
        public static Dictionary<int, StateCodeAdapterDTO> StateCodeAdaptorDictionary = new Dictionary<int, StateCodeAdapterDTO>();
      
        /// <summary>
        /// No-Arg Constructor
        /// </summary>
        public AdaptorIndianCensusImpl(ICensus CensusObj)
        {
            this.CensusObj = CensusObj;
        }

        /// <summary>
        /// Creates the india census adaptor.
        /// </summary>
        /// <param name="CensusObj">The census object.</param>
        /// <returns></returns>
        public static IAdaptorCensus CreateIndiaCensusAdaptor(ICensus CensusObj)
        {
            return new AdaptorIndianCensusImpl(CensusObj);
        }

        /// <summary>
        /// Converts the census.
        /// </summary>
        /// <returns></returns>
       public void ConvertCensus()
        {
            int count = 0;
            if (CensusObj.GetType().ToString().Equals("CensusAnalyser.CSVStateCensus"))
            {
                StateCensusAdapterDTO newstatecensusObj = null;
                foreach (KeyValuePair<int, StateCensusDataDAO> keyvalueState in CSVStateCensus.CensusDataDictionary)
                {
                    newstatecensusObj = new StateCensusAdapterDTO();
                    newstatecensusObj.SetStateName(keyvalueState.Value.StateName);
                    newstatecensusObj.SetPopulation(keyvalueState.Value.Population);
                    newstatecensusObj.SetArea(keyvalueState.Value.AreaInSqKm);
                    newstatecensusObj.SetDensity(keyvalueState.Value.DensityPerSqKm);
                    StateCensusAdapterDictionary.Add(++count, newstatecensusObj);
                }
            }
            else if(CensusObj.GetType().ToString().Equals("CensusAnalyser.CSVStateCode"))
            {
                StateCodeAdapterDTO newdtoObj = null;// 
                foreach (KeyValuePair<int, StateCodeDataDAO> keyvalueState in CSVStateCode.CensusCodeDictionary)
                {
                    newdtoObj = new StateCodeAdapterDTO();
                    newdtoObj.SetStateName(keyvalueState.Value.StateName);
                    newdtoObj.SetSerialNumber(keyvalueState.Value.SerialNo);
                    newdtoObj.SetStateCode(keyvalueState.Value.StateCode);
                    newdtoObj.SetTIN(keyvalueState.Value.TIN);
                    StateCodeAdaptorDictionary.Add(++count, newdtoObj);
                }
            }
        }
    }
     
    /// <summary>
    /// method to convert the USCensus data to readable form by CensusDAO
    /// </summary>
    public class USCensusAdapterIMPL : IAdaptorCensus
    {
        private ICensus CensusObj = null;
        public static Dictionary<int, USCensusAdapterDTO> USCensusAdapterDictionary = new Dictionary<int, USCensusAdapterDTO>();

        /// <summary>
        /// Prevents a default instance of the <see cref="USCensusAdapterIMPL"/> class from being created.
        /// </summary>
        private USCensusAdapterIMPL(ICensus CensusObj)
        {
            this.CensusObj = CensusObj;
        }

        /// <summary>
        /// Creates the us census implementation adapter.
        /// </summary>
        /// <returns></returns>
        public static IAdaptorCensus CreateUSCensusIMPLAdapter(ICensus CensusObj)
        {
            return new USCensusAdapterIMPL(CensusObj);
        }

        /// <summary>
        /// Converts the census.
        /// </summary>
        /// <returns></returns>
        public void ConvertCensus()
        {
            if (CensusObj.GetType().ToString().Equals("CensusAnalyser.USCensus"))
            {
                USCensusAdapterDTO newstatecensusObj = null;
                int count = 0;
                foreach (KeyValuePair<int, USCensusDataDAO> keyvalueState in USCensus.USCensusDictionary)
                { 
                    newstatecensusObj = new USCensusAdapterDTO(); 
                    newstatecensusObj.SetStateName(keyvalueState.Value.State);
                    newstatecensusObj.SetPopulation(keyvalueState.Value.Population);
                    newstatecensusObj.SetStateCode(keyvalueState.Value.StateId);
                    newstatecensusObj.SetHousingUnit(keyvalueState.Value.HousingUnits);
                    newstatecensusObj.SetHousingDensity(keyvalueState.Value.HousingDensity);
                    newstatecensusObj.SetPopulationDensity(keyvalueState.Value.PopulationDensity); 
                    newstatecensusObj.SetTotalArea(keyvalueState.Value.TotalArea);
                    newstatecensusObj.SetWaterArea(keyvalueState.Value.WaterArea);
                    newstatecensusObj.SetLandArea(keyvalueState.Value.LandArea);
                    ////Add into dictionary
                    USCensusAdapterDictionary.Add(++count, newstatecensusObj);
                }
            }
        }
    }
}

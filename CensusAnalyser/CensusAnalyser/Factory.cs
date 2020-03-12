
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// CensusFactory class to create and return ICensus Object
    /// </summary>
    public class CensusFactory 
    {
        public static ICensus create(string type)
        {
            ICensus CensusObj;
            if (type.Equals("StateCensusAnalyser"))
            {
                CensusObj = new StateCensusAnalyser();
            }
            else if (type.Equals("CSVStateCensus"))
            {
                CensusObj = new CSVStateCensus();
            }
            else if (type.Equals("CSVStateCode"))
            {
                CensusObj = new CSVStateCode();
            }
            else
                CensusObj = null;

            return CensusObj;
        }
    }

}

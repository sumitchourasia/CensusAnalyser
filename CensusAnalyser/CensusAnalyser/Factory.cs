
namespace CensusAnalyser
{
    /// <summary>
    /// CensusFactory class to create and return ICensus Object
    /// </summary>
    public class CensusFactory 
    {
        public static ICensusDAO create(string type)
        {
            ICensusDAO CensusObj;
            if (type.Equals("StateCensusAnalyser"))
            {
                CensusObj = new StateCensusAnalyser();
            }
            else if (type.Equals("CSVStateCensus"))
            {
                CensusObj = new CSVStateCensusDAOIMPL();
            }
            else if (type.Equals("CSVStateCode"))
            {
                CensusObj = new CSVStateCodeDAOIMPL();
            }
            else
                CensusObj = null;

            return CensusObj;
        }
    }
}


namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Class StateCensusData Implements IComparable<>
    /// </summary>
    /// <seealso cref="System.IComparable{CensusAnalyser.ListNode}" />
    public class NodeStateCensusData 
    {
        /// <summary>
        /// statename
        /// </summary>
        public string StateName;

        /// <summary>
        /// population
        /// </summary>
        public int Population;

        /// <summary>
        /// area in sq km
        /// </summary>
        public int AreaInSqKm;

        /// <summary>
        /// density per sq km
        /// </summary>
        public int DensityPerSqKm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListNode"/> class.
        /// </summary>
        public NodeStateCensusData()
        {

        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static NodeStateCensusData createNode(string element)
        {
            NodeStateCensusData newnode = null;
            try
            {
                if (element.Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
                    return null;
                newnode = new NodeStateCensusData();
                string[] arr = element.Split(",");
                newnode.StateName = arr[0];
                newnode.Population = Convert.ToInt32(arr[1]);
                if (arr[2] != null)
                    newnode.AreaInSqKm = Convert.ToInt32(arr[2]);
                if (arr[3] != null)
                    newnode.DensityPerSqKm = Convert.ToInt32(arr[3]);
                return newnode;
            }
            catch (Exception )
            {
                return newnode;
            }
        }
    }

    /// <summary>
    /// Modal class for CSVStateCode file
    /// </summary>
    /// <seealso cref="System.IComparable{CensusAnalyser.StateCode}" />
    public class NodeStateCodeData 
    {
        public int SerialNo;
        public string StateName;
        public int TIN;
        public string StateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListNodeStateCode"/> class.
        /// </summary>
        public NodeStateCodeData()
        {

        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static NodeStateCodeData createNode(string element)
        {
            NodeStateCodeData newnode = null;
            try
            {
                if (element.Equals("SrNo,State,Name,TIN,StateCode,"))
                    return null;
                newnode = new NodeStateCodeData();
                string[] arr = element.Split(",");
                newnode.SerialNo = Convert.ToInt32(arr[0]); 
                newnode.StateName = arr[1];
                newnode.TIN = Convert.ToInt32(arr[2]);
                newnode.StateCode = arr[3];
                return newnode;
            }
            catch (Exception )
            {
                return newnode;
            }
        }
    }
}


namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Class ListNodeStateData Implements IComparable<>
    /// </summary>
    /// <seealso cref="System.IComparable{CensusAnalyser.ListNode}" />
    public class ListNodeStateData : IComparable<ListNodeStateData>
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
        public ListNodeStateData()
        {

        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo([AllowNull] ListNodeStateData other)
        {
            return this.StateName.CompareTo(other.StateName);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ListNodeStateData createNode(string element)
        {
            ListNodeStateData newnode = null;
            try
            {
                if (element.Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
                    return null;
                newnode = new ListNodeStateData();
                string[] arr = element.Split(",");
                newnode.StateName = arr[0];
                newnode.Population = Convert.ToInt32(arr[1]);
                if (arr[2] != null)
                    newnode.AreaInSqKm = Convert.ToInt32(arr[2]);
                if (arr[3] != null)
                    newnode.DensityPerSqKm = Convert.ToInt32(arr[3]);
                return newnode;
            }
            catch (Exception e)
            {
                return newnode;
            }
        }
    }

    /// <summary>
    /// Modal class for CSVStateCode file
    /// </summary>
    /// <seealso cref="System.IComparable{CensusAnalyser.ListNodeStateCode}" />
    public class ListNodeStateCode : IComparable<ListNodeStateCode>
    {
        //  SrNo,State,Name,TIN,StateCode,
        public int SerialNo;
        public string StateName;
        public int TIN;
        public string StateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListNodeStateCode"/> class.
        /// </summary>
        public ListNodeStateCode()
        {

        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo([AllowNull] ListNodeStateCode other)
        {
            return this.StateCode.CompareTo(other.StateCode);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ListNodeStateCode createNode(string element)
        {
            ListNodeStateCode newnode = null;
            try
            {
                if (element.Equals("SrNo,State,Name,TIN,StateCode,"))
                    return null;
                newnode = new ListNodeStateCode();
                string[] arr = element.Split(",");
                newnode.SerialNo = Convert.ToInt32(arr[0]); 
                newnode.StateName = arr[1];
                newnode.TIN = Convert.ToInt32(arr[2]);
                newnode.StateCode = arr[3];
                return newnode;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in CreateNode");
                return newnode;
            }
        }
    }
}

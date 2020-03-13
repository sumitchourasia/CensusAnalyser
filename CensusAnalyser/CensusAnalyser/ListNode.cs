
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Class ListNode Implements IComparable<>
    /// </summary>
    /// <seealso cref="System.IComparable{CensusAnalyser.ListNode}" />
    public class ListNode : IComparable<ListNode>
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
        public ListNode()
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
        public int CompareTo([AllowNull] ListNode other)
        {
            return this.StateName.CompareTo(other.StateName);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static  ListNode createNode(string element)
        {
            ListNode newnode = null;
            try
            {
                if (element.Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
                    return null;
                newnode = new ListNode();
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
}

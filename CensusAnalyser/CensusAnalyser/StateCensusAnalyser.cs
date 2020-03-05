using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    /// <summary>
    /// contains method to load csv file and use iterator(IEnumerable)
    /// </summary>
    public class StateCensusAnalyser 
    {
        int count = 0;
        /// <summary>
        /// Gets the iterator.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetIterator(string path)
        {
            //// Iterating array elements and returning  
            foreach (string line in File.ReadLines(path))
                yield return line; //// It returns elements after executing each iteration  
        }
        /// <summary>
        /// Load the states census file.
        /// uses iterator(IEnumeration)
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public int LoadstateCensusFile(string path)
        {
            IEnumerable<string> elements = StateCensusAnalyser.GetIterator(path);
            foreach (string element in elements)
                count++;
            return count;
        }
    }
}

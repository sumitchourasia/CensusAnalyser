using System;

namespace CensusAnalyser
{
    /// <summary>
    /// contains main method
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main()
        {
            string pathCSVStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            StateCensusAnalyser obj3 = new StateCensusAnalyser();
            Console.WriteLine(obj3.LoadCSVFile(pathCSVStateCode));
        }
    }
}

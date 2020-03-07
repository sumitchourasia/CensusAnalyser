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
            /*  string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
              Console.WriteLine("Welcome to Census Analyser!");
              StateCensusAnalyser obj = new StateCensusAnalyser();
              Console.WriteLine( obj.LoadstateCensusFile(path));
              CSVStateCensus obj2 = new CSVStateCensus();
              Console.WriteLine(obj2.LoadCSVStateCensusFile(path));*/
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            StateCensusAnalyser obj3 = new StateCensusAnalyser();
            Console.WriteLine(obj3.LoadCSVstateCodesFile(path));
        }
    }
}

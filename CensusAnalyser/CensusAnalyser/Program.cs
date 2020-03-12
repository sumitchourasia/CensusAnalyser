/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System;
    using static CensusAnalyser.StateCensusAnalyser;

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
            string PathFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            dynamic CensusAnalyserObject = MyDelegate.CreateCensusUsingBuilder("CSVStateCensus", PathFile , ",");
            string actual = CensusAnalyserObject();
            Console.WriteLine(actual);
        }
    }
}

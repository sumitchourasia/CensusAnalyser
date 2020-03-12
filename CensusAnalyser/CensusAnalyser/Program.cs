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
            string Path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
           
            IBuilder builderObject = BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(Path);
            BuilderDirector.ConstructDelimiter(",");
            BuilderDirector.ConstructHeader("SrNo,State,Name,TIN,StateCode,");

            ICensus censusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(builderObject,censusObj);

            dynamic a = MyDelegate.CreateCensusAnalyserDelegate(censusObj);
            Console.WriteLine(a());

            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
            IBuilder builderObj1 = BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(path);

            ICensus stateObj1 = BuilderDirector.ConstructCensusUsingFactory("StateCensusAnalyser");
            BuilderDirector.Construt(builderObj1, stateObj1);

            dynamic StateObject = MyDelegate.CreateCensusAnalyserDelegate(stateObj1);
           Console.WriteLine( StateObject());
        }
    }
}

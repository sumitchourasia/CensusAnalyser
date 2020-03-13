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
            string PathFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";

            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            dynamic CensusDelegate = MyDelegate.CreateCensusAnalyserLoadFileDelegate(CensusObj);
            Console.WriteLine(CensusDelegate.GetType());
            Console.WriteLine(CensusDelegate());
            CensusObj.PrintList(CensusObj);
            CensusObj.SortList();
            CensusObj.PrintList(CensusObj);
            dynamic Serializedelegate = MyDelegate.CreateSerializeDelegate(CensusObj);
            Console.WriteLine(Serializedelegate.GetType());
            Serializedelegate();
        }
    }
}

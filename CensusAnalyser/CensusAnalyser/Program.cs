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

            IBuilder builderObj = BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(builderObj, CensusObj);
            Console.WriteLine(builderObj.GetType());
            Console.WriteLine(CensusObj.GetType());
            dynamic CensusDelegate = MyDelegate.CreateCensusAnalyserDelegate(CensusObj);
            Console.WriteLine(CensusDelegate());

            MyDelegate.SerializeDelegate delegateobj = new MyDelegate.SerializeDelegate(CensusObj.Serialize);
            delegateobj(CensusObj);
        }
    }
}

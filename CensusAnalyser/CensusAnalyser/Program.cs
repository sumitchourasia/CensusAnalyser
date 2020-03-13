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
            string PathCSVFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
            string PathCSVCodeFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            string PathStateName = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string PathstateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.json";

            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVFile);
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
            Serializedelegate(PathStateName);
            Census.FirstAndLastItemStateNameJson(PathStateName);

            /// for stare code
            BuilderDirector.CreateBuilder(); 
            BuilderDirector.ConstructPath(PathCSVCodeFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj2 = BuilderDirector.ConstructCensusUsingFactory("CSVStateCode");
            BuilderDirector.Construt(CensusObj2);
            dynamic CensusDelegate2 = MyDelegate.CreateCensusAnalyserLoadFileDelegate(CensusObj2);
            Console.WriteLine(CensusDelegate2.GetType());
            Console.WriteLine(CensusDelegate2());
            CensusObj2.PrintList(CensusObj2);
            CensusObj2.SortList();
            CensusObj2.PrintList(CensusObj2);
            dynamic Serializedelegate2 = MyDelegate.CreateSerializeDelegate(CensusObj2);
            Console.WriteLine(Serializedelegate2.GetType());
            Serializedelegate2(PathstateCode);
            Census.FirstAndLastItemStateCodeJson(PathstateCode);
        }
    }
}

/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
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
            string JsonPathStateName = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";

            ////without using delegate
/*
            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            CensusObj.LoadCSVFile();
            CensusObj.SortDictionary();
            CensusObj.SerializeDictionary(JsonPathStateName);
            CensusObj.PrintDictionary();
            string data = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int, ListNodeStateData>>(JsonPathStateName);
            Console.WriteLine("data :" + data);
*/

            ////using delegate
            dynamic delegateobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", PathCSVFile);
            delegateobj();
            ICensus CensusObj2 = BuilderDirector.GetCensus();
            CensusObj2.SortDictionary();
            CensusObj2.PrintDictionary();
            dynamic serializedelgateobj = MyDelegate.CreateSerializeDelegate(CensusObj2);
            serializedelgateobj(JsonPathStateName);
            string data2 = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int, ListNodeStateData>>(JsonPathStateName);
            Console.WriteLine("data2 :" + data2);
        }
    }
}

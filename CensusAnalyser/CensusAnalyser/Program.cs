/// <summary>
/// namespace census analyser
/// </summary
namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;

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
            string PathCSVDataFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
            string PathCSVCodeFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            string JsonPathStateData = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string JsonPathStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.json";
           
            ////without using delegate
            /* BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVDataFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            CensusObj.LoadCSVFile();
            CensusObj.SortDictionary();
            CensusObj.SerializeDictionary(JsonPathStateData);
            CensusObj.PrintDictionary();
            string data = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int, NodeStateCensusData>>(JsonPathStateData);
            Console.WriteLine("data :" + data);*/

            ////using delegate for CSVStateData file
            dynamic delegateDataobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", PathCSVDataFile);
            delegateDataobj();
            ICensus CensusObj2 = BuilderDirector.GetCensus();
            CensusObj2.SortDictionary();
            dynamic serializedelgateobj = MyDelegate.CreateSerializeDelegate(CensusObj2);
            serializedelgateobj(JsonPathStateData);
            string data2 = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int, NodeStateCensusData>>(JsonPathStateData);
            Console.WriteLine("state census data file first and last statename data :" + data2); 

            ////using delegate for CSVStateCode FIle
            dynamic delegateCodeobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", PathCSVCodeFile);
            delegateCodeobj();
            ICensus CensusObj3 = BuilderDirector.GetCensus();
            CensusObj3.SortDictionary();
            dynamic serializedelgateobj3 = MyDelegate.CreateSerializeDelegate(CensusObj3);
            serializedelgateobj3(JsonPathStateCode);
            string data3 = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int, NodeStateCodeData>>(JsonPathStateCode);
            Console.WriteLine("state code file first and last state name data :" + data3);
        }
    }
}

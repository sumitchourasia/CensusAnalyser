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
    public class Program
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
            string JsonPathMostPopulous = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\MostPopulous.json";
            string JsonPathPopulationDensity = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\PopulationDensity.json";

          /*  ////without using delegate
            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVDataFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensusDAO CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            CensusObj.LoadCSVFile();
            CensusObj.SortDictionary();
            CensusObj.SerializeDictionary(JsonPathStateData);
            CensusObj.PrintDictionary();
            string data = CensusObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusDataDAO>>(JsonPathStateData);
            Console.WriteLine("data :" + data);
            CensusObj.SortDictionaryMostPopulous();
            CensusObj.SerializeDictionary(JsonPathMostPopulous);
            CensusObj.PrintDictionary();
*/

            ////using delegate for CSVStateData file sort based on StateName
            dynamic delegateDataobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", PathCSVDataFile);
            delegateDataobj();
            ICensusDAO CensusObj2 = BuilderDirector.GetCensus();
            CensusObj2.SortDictionary();
            Console.WriteLine("\n\n\n based on StateName \n\n\n");
            CensusObj2.PrintDictionary();
            dynamic serializedelgateobj = MyDelegate.CreateSerializeDelegate(CensusObj2); 
            serializedelgateobj(JsonPathStateData);
            string data2 = CensusObj2.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusDataDAO>>(JsonPathStateData);
            Console.WriteLine("state census data file first and last statename data :" + data2);

            //// sort based on population
            Console.WriteLine("\n\n\n based on population \n\n\n");
            CensusObj2.SortDictionaryMostPopulous();
            CensusObj2.SerializeDictionary(JsonPathMostPopulous);
            CensusObj2.PrintDictionary("Population");

            ////sort based on population density 
            Console.WriteLine("\n\n\n based on population \n\n\n");
            CensusObj2.SortDictionaryPopulationDensity();
            CensusObj2.SerializeDictionary(JsonPathPopulationDensity);

            ////using delegate for CSVStateCode FIle sort based on statecode
            dynamic delegateCodeobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", PathCSVCodeFile);
            delegateCodeobj();
            ICensusDAO CensusObj3 = BuilderDirector.GetCensus();
            CensusObj3.SortDictionary();
            Console.WriteLine("\n\n\n based on StateCode \n\n\n");
            CensusObj3.PrintDictionary();
            dynamic serializedelgateobj3 = MyDelegate.CreateSerializeDelegate(CensusObj3);
            serializedelgateobj3(JsonPathStateCode);
            string data3 = CensusObj3.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCodeDataDAO>>(JsonPathStateCode);
            Console.WriteLine("state code file first and last state name data :" + data3);
        }
    }
}

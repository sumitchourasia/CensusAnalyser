﻿/// <summary>
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
            string PathUSCensusDataFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\USCensusData.csv";
            string JsonPathStateData = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string JsonPathStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.json";
            string JsonPathMostPopulous = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\MostPopulous.json";
            string JsonPathPopulationDensity = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\PopulationDensity.json";
            string JsonPathMostArea = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\MostArea.json";
            

            /* ////without using delegate
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

            /* ////using delegate for CSVStateData file sort based on StateName
             dynamic delegateDataobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", PathCSVDataFile);
             delegateDataobj();
             ICensus CensusObj2 = BuilderDirector.GetCensus();
             ICensusDAO CensusdaoObj = new CensusDAO(CensusObj2);

             Console.WriteLine(CensusObj2.GetType());
             Console.WriteLine(CensusdaoObj.GetType());

             CensusdaoObj.SortDictionary();
             Console.WriteLine("\n\n\n based on StateName \n\n\n");
             CensusdaoObj.PrintDictionary(CensusObj2, "StateName");
             dynamic serializedelgateobj = MyDelegate.CreateSerializeDelegate(CensusObj2);
             serializedelgateobj(JsonPathStateData);
             CensusdaoObj.SerializeDictionary(JsonPathStateData);
             string data2 = CensusdaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusDataDAO>>(JsonPathStateData);
             Console.WriteLine("state census data file first and last statename data :" + data2);

             //// sort based on population
             Console.WriteLine("\n\n\n based on population \n\n\n");
             CensusdaoObj.SortDictionaryMostPopulous();
             CensusdaoObj.SerializeDictionary(JsonPathMostPopulous);
             CensusdaoObj.PrintDictionary(CensusObj2, "Population");

             ////sort based on population density 
             Console.WriteLine("\n\n\n based on population density \n\n\n");
             CensusdaoObj.SortDictionaryPopulationDensity();
             CensusdaoObj.SerializeDictionary(JsonPathPopulationDensity);
             CensusdaoObj.PrintDictionary(CensusObj2, "Density");

             ////sort based on Area in Descending order 
             Console.WriteLine("\n\n\n based on Area Descending order \n\n\n");
             CensusdaoObj.SortDictionaryMostArea();
             CensusdaoObj.SerializeDictionary(JsonPathMostArea);
             CensusdaoObj.PrintDictionary(CensusObj2, "Area");

             ////using delegate for CSVStateCode FIle sort based on statecode
             dynamic delegateCodeobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", PathCSVCodeFile);
             delegateCodeobj();
             ICensus CensusObj3 = BuilderDirector.GetCensus();
             ICensusDAO CensusdaoObj2 = new CensusDAO(CensusObj3);
             CensusdaoObj2.SortDictionary();
             Console.WriteLine("\n\n\n based on StateCode \n\n\n");
             CensusdaoObj2.PrintDictionary(CensusObj3);
             dynamic serializedelgateobj3 = MyDelegate.CreateSerializeDelegate(CensusObj3);
             serializedelgateobj3(JsonPathStateCode);
             CensusdaoObj2.SerializeDictionary(JsonPathStateCode);
             string data3 = CensusdaoObj2.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCodeDataDAO>>(JsonPathStateCode);
             Console.WriteLine("state code file first and last state name data :" + data3);*/

          /*  dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", PathCSVCodeFile);
            CensusAnalyserDelegate();
            ICensus censusObj = BuilderDirector.GetCensus();
            ICensusDAO censusdaoObj = new CensusDAO(censusObj);
            censusdaoObj.SortDictionary();
            censusdaoObj.SerializeDictionary(JsonPathStateCode);
            string actual = censusdaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCodeDataDAO>>(JsonPathStateCode);
            string expected = "Andhra Pradesh New" + "West Bengal";
            Console.WriteLine(actual);*/ 


            dynamic delegateDataobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("USCensus", PathUSCensusDataFile);
            delegateDataobj();
            ICensus CensusObj2 = BuilderDirector.GetCensus();
            ICensusDAO CensusdaoObj = new CensusDAO(CensusObj2);

            CensusdaoObj.PrintDictionary(CensusObj2);

            Console.WriteLine(CensusObj2.GetType());
            Console.WriteLine(CensusdaoObj.GetType());

           
        }
    }
}

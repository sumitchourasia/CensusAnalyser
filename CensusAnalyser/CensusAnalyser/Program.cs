﻿/// <summary>
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
            string PathCSVCodeFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            string PathStateName = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string PathstateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.json";

          /*  BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            dynamic CensusDelegate = MyDelegate.CreateCensusAnalyserLoadFileDelegate(CensusObj);
            Console.WriteLine(CensusDelegate.GetType());
            Console.WriteLine(CensusDelegate());
            Console.WriteLine();
            Console.WriteLine("printing the list before sorting"); 
            Console.WriteLine();
            CensusObj.PrintList();
            CensusObj.SortList();
            Console.WriteLine();
            Console.WriteLine("printing the list after sorting"); 
            Console.WriteLine(); 
            CensusObj.PrintList(); 
            CensusObj.PrintDictionary(); 
            dynamic Serializedelegate = MyDelegate.CreateSerializeDelegate(CensusObj); 
            Console.WriteLine(Serializedelegate.GetType()); 
            Serializedelegate(PathStateName); 
            string data = Census.FirstAndLastItemStateCodeGenerics<List<ListNodeStateData>>(PathStateName); 
            Console.WriteLine("data is " + data); 
            CensusObj.SortDictionary(); 
            CensusObj.SerializeDictionary(PathStateName); 
            Console.WriteLine("\n\n");
            Console.WriteLine("print the dictionary");*/



            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);

            ICensus CensusObj3 = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj3);

            dynamic CensusDelegate3 = MyDelegate.CreateCensusAnalyserLoadFileDelegate(CensusObj3);

            Console.WriteLine(CensusDelegate3());

           
            CensusObj3.SortDictionary();

           

            CensusObj3.SerializeDictionary(PathStateName);
            Console.WriteLine("\n\n");
            Console.WriteLine("print the dictionary");

            string data = Census.FirstAndLastItemStateCodeGenerics<Dictionary<int,ListNodeStateData>>(PathStateName);
            Console.WriteLine("data :"+ data);



            /*  /// for stare code
              BuilderDirector.CreateBuilder(); 
              BuilderDirector.ConstructPath(PathCSVCodeFile);
              BuilderDirector.ConstructDelimiter(null);
              BuilderDirector.ConstructHeader(null);
              ICensus CensusObj2 = BuilderDirector.ConstructCensusUsingFactory("CSVStateCode");
              BuilderDirector.Construt(CensusObj2);
              dynamic CensusDelegate2 = MyDelegate.CreateCensusAnalyserLoadFileDelegate(CensusObj2);
              Console.WriteLine(CensusDelegate2.GetType());
              Console.WriteLine(CensusDelegate2());
              //CensusObj2.PrintList(CensusObj2);
              CensusObj2.SortList();
             // CensusObj2.PrintList(CensusObj2);
              dynamic Serializedelegate2 = MyDelegate.CreateSerializeDelegate(CensusObj2);
              Console.WriteLine(Serializedelegate2.GetType());
              Serializedelegate2(PathstateCode);

              //generics
             string data2 = Census.FirstAndLastItemStateCodeGenerics<List<ListNodeStateCode>>(PathstateCode);
              Console.WriteLine("data2 is "+data2);*/
        }

      
    }
}

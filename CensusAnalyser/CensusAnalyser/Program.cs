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
            /*string PathCSVDataFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
            string PathCSVCodeFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
            string PathUSCensusDataFile = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\USCensusData.csv";
            string JsonPathStateData = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateName.json";
            string JsonPathStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.json";
            string JsonPathMostPopulous = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\MostPopulous.json";
            string JsonPathPopulationDensity = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\PopulationDensity.json";
            string JsonPathMostArea = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\MostArea.json";
            string JsonPathUSCensusMostPopulation = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\USCensusPopulation.json";
*/

            string PathCSVDataFile = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";
            string PathCSVCodeFile = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCode.csv";
            string PathUSCensusDataFile = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\USCensusData.csv";
            string JsonPathStateData = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateName.json";
            string JsonPathStateCode = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCode.json";
            string JsonPathMostPopulous = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\MostPopulous.json";
            string JsonPathPopulationDensity = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\PopulationDensity.json";
            string JsonPathMostArea = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\MostArea.json";
            string JsonPathUSCensusMostPopulation = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\USCensusPopulation.json";

           /* ////without using delegate
            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(PathCSVDataFile);
            BuilderDirector.ConstructDelimiter(null);
            BuilderDirector.ConstructHeader(null);
            ICensus CensusObj = BuilderDirector.ConstructCensusUsingFactory("CSVStateCensus");
            BuilderDirector.Construt(CensusObj);
            CensusObj.LoadCSVFile();
            ////adaptor object
            IAdaptorCensus adapterobj = new AdaptorIndianCensusImpl(CensusObj);
            adapterobj.ConvertCensus();
            //// census dao object
            ICensusDAO CensusDaoObj = BuilderDirector.CreateCensusDAO();
            CensusDaoObj.SortDictionary(CensusObj,"StateName");
            CensusDaoObj.SerializeDictionary(JsonPathStateData);
            CensusDaoObj.PrintDictionary(CensusObj, "StateName");
            string data = CensusDaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusAdapterDTO>>(JsonPathStateData);
            Console.WriteLine("data :" + data);*/


            ////using delegate for CSVStateData file sort based on StateName
            dynamic delegateDataobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", PathCSVDataFile);
            delegateDataobj(); 
            ICensus CensusObj2 = BuilderDirector.GetCensus();
            ////adapter
            BuilderDirector.ConvertCensusUsingAdapter(CensusObj2);
            //// censusDao
            ICensusDAO CensusdaoObj = BuilderDirector.CreateCensusDAO();
            ///censusdao 
            CensusdaoObj.SortDictionary(CensusObj2 ,"StateName");
            Console.WriteLine("\n\n\n indian census data based on StateName \n\n\n"); 
            CensusdaoObj.PrintDictionary(CensusObj2, "StateName");
            dynamic serializedelgateobj = MyDelegate.CreateSerializeDelegate(CensusdaoObj);
            serializedelgateobj(JsonPathStateData);  

             string data2 = CensusdaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusAdapterDTO>>(JsonPathStateData);
             Console.WriteLine("state census data file first and last statename data :" + data2);
           
            //// sort based on population
            Console.WriteLine("\n\n\n based on population \n\n\n");
            CensusdaoObj.SortDictionary(CensusObj2,"Population");
            serializedelgateobj(JsonPathMostPopulous);  
            CensusdaoObj.PrintDictionary(CensusObj2, "Population");
            
            ////sort based on population density 
            Console.WriteLine("\n\n\n based on population density \n\n\n");
            CensusdaoObj.SortDictionary(CensusObj2,"Density"); 
            serializedelgateobj(JsonPathPopulationDensity); 
            CensusdaoObj.PrintDictionary(CensusObj2, "Density");

            ////sort based on Area in Descending order 
            Console.WriteLine("\n\n\n based on Area Descending order \n\n\n");
            CensusdaoObj.SortDictionary(CensusObj2,"Area"); 
            serializedelgateobj(JsonPathMostArea); 
            CensusdaoObj.PrintDictionary(CensusObj2, "Area");
           
            ////using delegate for CSVStateCode FIle sort based on statecode
            dynamic delegateCodeobj = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", PathCSVCodeFile);
            delegateCodeobj(); 
            ICensus CensusObj3 = BuilderDirector.GetCensus();
            BuilderDirector.ConvertCensusUsingAdapter(CensusObj3);
            CensusdaoObj.SortDictionary(CensusObj3 , "StateCode");  
            Console.WriteLine("\n\n\n based on StateCode \n\n\n");
            CensusdaoObj.PrintDictionary(CensusObj3, "StateCode");
            serializedelgateobj(JsonPathStateCode);

            //// merge indian census
            CensusdaoObj.CreateIndianCensus();
            serializedelgateobj(@"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\Merged.json");

            
            ////uscensus 
            dynamic USCensusLoadDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("USCensus", PathUSCensusDataFile);
            USCensusLoadDelegate();
            ICensus USCensusObj = BuilderDirector.GetCensus();  
            ////adapter
            BuilderDirector.ConvertCensusUsingAdapter(USCensusObj);
            //// censusDao
            ICensusDAO USCensusdaoObj = BuilderDirector.CreateCensusDAO();
            USCensusdaoObj.SortDictionary(USCensusObj,"Population");
            USCensusdaoObj.PrintDictionary(USCensusObj);
            ////serialize using delegate
            dynamic serializedelgateobj2 = MyDelegate.CreateSerializeDelegate(USCensusdaoObj);
            serializedelgateobj2(JsonPathUSCensusMostPopulation);
        }
    }
}

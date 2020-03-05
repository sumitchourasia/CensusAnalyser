using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";

            Console.WriteLine("Welcome to Census Analyser!");
            StateCensusAnalyser obj = new StateCensusAnalyser();
            Console.WriteLine( obj.LoadstateCensusFile(path));
            CSVStateCensus obj2 = new CSVStateCensus();
            Console.WriteLine(obj2.LoadCSVStateCensusFile(path));
        }
    }
}

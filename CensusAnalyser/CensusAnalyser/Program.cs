using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Census Analyser!");
            StateCensusAnalyser obj = new StateCensusAnalyser();
            obj.GetDataTabletFromCSVFile();

            CSVStateCensus obj2 = new CSVStateCensus();
            obj2.LoadFile();
        }
    }
}

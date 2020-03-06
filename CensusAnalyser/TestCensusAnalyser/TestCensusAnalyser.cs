using CensusAnalyser;
using NUnit.Framework;

namespace TestCensusAnalyser
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void HappyCaseRecordMatch()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            int StateCensusAnalyserRecords =  obj.LoadstateCensusFile(path);
            CSVStateCensus obj2 = new CSVStateCensus();
            int CSVStateCensusRecords = obj2.LoadCSVStateCensusFile(path);
            Assert.AreEqual(StateCensusAnalyserRecords , CSVStateCensusRecords);
        }
    }
}
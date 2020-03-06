using CensusAnalyser;
using NUnit.Framework;

namespace TestCensusAnalyser
{
    /// <summary>
    /// contains all the test cases
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Happy test case for no of records matching in both the classes.
        /// </summary>
        [TestCase]
        public void HappyCaseRecordMatch()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            var StateCensusAnalyserRecords =  obj.LoadstateCensusFile(path);
            CSVStateCensus obj2 = new CSVStateCensus();
            var CSVStateCensusRecords = obj2.LoadCSVStateCensusFile(path);
            Assert.AreEqual(StateCensusAnalyserRecords , CSVStateCensusRecords);
        }

        /// <summary>
        /// Sad test case in case of incorrect file path.
        /// </summary>
        [TestCase]
        public void SadCaseIncorrectFilePath()
        {
            string path = "wrong file path";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            string ActualException =obj.LoadstateCensusFile(path);
            string ExpectedException = Enum_Exception.No_Such_File_Exception.ToString();
            Assert.AreEqual(ActualException,ExpectedException);
        }


    }
}
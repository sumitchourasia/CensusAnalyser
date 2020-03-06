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
        /// test case 1.1
        /// Happy test case for no of records matching in both the classes.
        /// </summary>
        [TestCase]
        public void HappyCaseRecordMatch()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            var StateCensusAnalyserRecords =  obj.LoadstateCensusFile(path);
            CSVStateCensus obj2 = new CSVStateCensus();
            var CSVStateCensusRecords = obj2.LoadCSVStateCensusFile(path);
            Assert.AreEqual(StateCensusAnalyserRecords , CSVStateCensusRecords);
        }
        /// <summary>
        /// test case 1.2
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
        /// <summary>
        /// test case 1.3
        /// test case of incorrect file Type .
        /// </summary>
        [TestCase]
        public void IncorrectFileTypeTest()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\WrongFileType.txt";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            string ActualException = obj.LoadstateCensusFile(path);
            string ExpectedException = Enum_Exception.File_Type_MisMatch_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }

        /// <summary>
        /// test case 1.4
        /// test case of Incorrect Delimiter .
        /// </summary>
        [TestCase]
        public void IncorrectDelimiterTest()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\WrongFileType.txt";
            string delimeter = ",";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            string ActualException = obj.LoadstateCensusFile(path,delimeter);
            string ExpectedException = Enum_Exception.Incorrect_Delimiter_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }

        /// <summary>
        /// test case 1.5
        /// test case of Incorrect Header .
        /// </summary>
        [TestCase]
        public void IncorrectHeaderTest()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\WrongFileType.txt";
            string Header1 = "St";
            string Header2 = "Poion";
            string Header3 = "AreaInSqKm";
            string Header4 = "DensityPerSqKm";
            StateCensusAnalyser obj = new StateCensusAnalyser();
            string ActualException = obj.LoadstateCensusFile(path, Header1,Header2,Header3,Header4);
            string ExpectedException = Enum_Exception.Incorrect_Header_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }
    }
}
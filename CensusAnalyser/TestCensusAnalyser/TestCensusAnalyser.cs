
/// <summary>
/// namespace census analyser
/// </summary
namespace TestCensusAnalyser
{
    using CensusAnalyser;
    using NUnit.Framework;
    using System.Collections.Generic;

    /// <summary>
    /// contains all the test cases
    /// </summary>
    [TestFixture]
    public class Tests
    {
        string pathCSVStateCodeFile = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCode.csv";
        string pathStateCensusDataFile = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";
        string JsonPathStateData = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateName.json";
        string JsonPathStateCode = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCode.json";

        /// <summary>
        /// test case 1.1
        /// Happy test case for no of records matching in both the classes.
        /// </summary>
        [TestCase]
        public void HappyCaseRecordMatch()
        {
            StateCensusAnalyser obj = new StateCensusAnalyser(pathStateCensusDataFile);
            var StateCensusAnalyserRecords = obj.LoadCSVFile();
            CSVStateCensus obj2 = new CSVStateCensus(pathStateCensusDataFile);
            var CSVStateCensusRecords = obj2.LoadCSVFile();
            Assert.AreEqual(StateCensusAnalyserRecords, CSVStateCensusRecords);
        }

        /// <summary>
        /// test case 1.2
        /// Sad test case in case of incorrect file path.
        /// </summary>
        [TestCase]
        public void SadCaseIncorrectFilePath()
        {
            string path = "wrong file path";
            CSVStateCensus obj = new CSVStateCensus(path);
            var ActualException = obj.LoadCSVFile();
            string ExpectedException = Enum_Exception.No_Such_File_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }

        /// <summary>
        /// test case 1.3
        /// test case of incorrect file Type .
        /// </summary>
        [TestCase]
        public void IncorrectFileTypeTest()
        {
            string path = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\WrongFileType.txt";
            CSVStateCensus obj = new CSVStateCensus(path);
            string ActualException = obj.LoadCSVFile();
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
            string delimeter = ".";
            CSVStateCensus obj = new CSVStateCensus(pathStateCensusDataFile, delimeter);
            string ActualException = obj.LoadCSVFile();
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
            string Header1 = "St";
            string Header2 = "Poion";
            string Header3 = "Area";
            string Header4 = "DentyPrSm";
            string Header = Header1 + Header2 + Header3 + Header4;
            CSVStateCensus obj = new CSVStateCensus(pathStateCensusDataFile, null, Header);
            string ActualException = obj.LoadCSVFile();
            string ExpectedException = Enum_Exception.Incorrect_Header_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }

        /// <summary>
        /// test case 2.1
        /// Happy case matches the records in CSVStateCode file.
        /// </summary>
        [TestCase]
        public void HappyCaseRecordsMatchCSVStateCode()
        {
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCodeFile);
            string actual = CensusAnalyserDelegate();

            dynamic StateCensusAnalyserObject = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("StateCensusAnalyser", pathCSVStateCodeFile);
            string expected = StateCensusAnalyserObject();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.2
        /// sad test case in case of incorrect CSVStateCode File Path throws custom exception.
        /// </summary>
        [TestCase]
        public void IncorrectCSVStateCodePathTest()
        {
            string pathCSVStateCode = @"wrongfilepath";
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCode);
            string actual = CensusAnalyserDelegate();
            string expected = Enum_Exception.No_Such_File_Exception.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.3
        /// sad test case in case of incorrect CSVStateCode File Path throws custom exception.
        /// </summary>
        [TestCase]
        public void IncorrectCSVStateCodeFileTypeTest()
        {
            string pathCSVStateCode = @"D:\CensusAnalyser\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\WrongFileType.txt";
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCode);
            string actual = CensusAnalyserDelegate();
            string expected = Enum_Exception.File_Type_MisMatch_Exception.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.4
        /// sad test case in case of incorrect delimiter throws custom exception.
        /// </summary>
        [TestCase]
        public void IncorrectCSVStateCodeFileCheckDelimiterTest()
        {
            string Delimiter = ".";
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCodeFile, Delimiter);
            string actual = CensusAnalyserDelegate();
            string expected = Enum_Exception.Incorrect_Delimiter_Exception.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.5
        /// test case of Incorrect Header .
        /// </summary>
        [TestCase]
        public void IncorrectHeaderCSVStateCodeTest()
        {
            string Header1 = "St";
            string Header2 = "Poion";
            string Header3 = "Area";
            string Header4 = "DentyPrSm";
            string Header = Header1 + Header2 + Header3 + Header4;
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCodeFile, null, Header);
            string ActualException = CensusAnalyserDelegate();
            string ExpectedException = Enum_Exception.Incorrect_Header_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }

        /// <summary>
        /// Test Case for usecase 3
        /// test the first and last state name are as expected for CSVStateData file
        /// using dictionary
        /// </summary>
        [TestCase] 
        public void SortStateNameTest() 
        {
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", pathStateCensusDataFile);
            CensusAnalyserDelegate();
            ICensus censusObj = BuilderDirector.GetCensus();
            BuilderDirector.ConvertCensusUsingAdapter(censusObj);
            ICensusDAO censusdaoObj = BuilderDirector.CreateCensusDAO();
            censusdaoObj.SortDictionary(censusObj, "StateName");
            censusdaoObj.SerializeDictionary(JsonPathStateData);
            string actual = censusdaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCensusAdapterDTO>>(JsonPathStateData);
            string expected = "Andhra Pradesh" + "West Bengal";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test Case for usecase 4
        /// test the first and last state name are as expected for CSVStateCode file
        /// using dictionary
        /// </summary>
        [TestCase]
        public void SortStateCodeTest()
        {
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCode", pathCSVStateCodeFile);
            CensusAnalyserDelegate();
            ICensus censusObj = BuilderDirector.GetCensus();
            BuilderDirector.ConvertCensusUsingAdapter(censusObj);
            ICensusDAO censusdaoObj = BuilderDirector.CreateCensusDAO();
            censusdaoObj.SortDictionary(censusObj,"StateCode");
            censusdaoObj.SerializeDictionary(JsonPathStateCode);
            string actual = censusdaoObj.FirstAndLastItemStateCodeGenerics<Dictionary<int, StateCodeAdapterDTO>>(JsonPathStateCode);
            string expected = "Andhra Pradesh New" + "West Bengal";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case for usecase 5
        /// test the total no of states sorted based on most population. 
        /// </summary>
        [TestCase]
        public void TotalStateSortedBasedOnMostPopulous()
        {
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusLoadFileDelegateUsingBuilder("CSVStateCensus", pathStateCensusDataFile);
            CensusAnalyserDelegate();
            ICensus censusObj = BuilderDirector.GetCensus();
            BuilderDirector.ConvertCensusUsingAdapter(censusObj); 
            ICensusDAO censusdaoObj = BuilderDirector.CreateCensusDAO();
            int Actual_NumberOfTotalStatesSorted = censusdaoObj.SortDictionary(censusObj,"Population");
            int expected = 29;
            Assert.AreEqual(expected, Actual_NumberOfTotalStatesSorted);
        }
    }
}

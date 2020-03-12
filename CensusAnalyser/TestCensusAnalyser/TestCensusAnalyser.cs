/*/// <summary>
/// namespace census analyser
/// </summary
namespace TestCensusAnalyser
{
    using CensusAnalyser;
    using NUnit.Framework;

    /// <summary>
    /// contains all the test cases
    /// </summary>
    [TestFixture]
    public class Tests
    {
        public static string pathCSVStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv";
        public static string pathStateCensusData = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCensusData.csv";

        /// <summary>
        /// test case 1.1
        /// Happy test case for no of records matching in both the classes.
        /// </summary>
        [TestCase]
        public void HappyCaseRecordMatch()
        {
            StateCensusAnalyser obj = new StateCensusAnalyser(pathStateCensusData);
            var StateCensusAnalyserRecords = obj.LoadCSVFile();
            CSVStateCensus obj2 = new CSVStateCensus(pathStateCensusData);
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
            CSVStateCensus obj = new CSVStateCensus(pathStateCensusData);
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
             string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\WrongFileType.txt";
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
             CSVStateCensus obj = new CSVStateCensus(pathStateCensusData,delimeter);
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
             CSVStateCensus obj = new CSVStateCensus(pathStateCensusData ,null,Header);
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
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusUsingBuilder("CSVStateCode",pathCSVStateCode);
            string actual = CensusAnalyserDelegate();

            dynamic StateCensusAnalyserObject = MyDelegate.CreateCensusUsingBuilder("StateCensusAnalyser",pathCSVStateCode);
            string expected = StateCensusAnalyserObject();
            Assert.AreEqual(actual,expected); 
         }

        /// <summary>
        /// test case 2.2
        /// sad test case in case of incorrect CSVStateCode File Path throws custom exception.
        /// </summary>
        [TestCase]
        public void IncorrectCSVStateCodePathTest()
        {
            string pathCSVStateCode = @"wrongfilepath";
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusUsingBuilder("CSVStateCode" , pathCSVStateCode);
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
            string pathCSVStateCode = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\WrongFileType.txt";
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusUsingBuilder("CSVStateCode", pathCSVStateCode);
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
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusUsingBuilder("CSVStateCode", pathCSVStateCode,Delimiter);
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
            dynamic CensusAnalyserDelegate = MyDelegate.CreateCensusUsingBuilder("CSVStateCode", pathCSVStateCode,null,Header);
            string ActualException = CensusAnalyserDelegate();
            string ExpectedException = Enum_Exception.Incorrect_Header_Exception.ToString();
            Assert.AreEqual(ActualException, ExpectedException);
        }
    }
}
*/

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

    /// <summary>
    /// Interface ICensus
    /// </summary>
    public interface ICensus
    {
        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns></returns>
        string LoadCSVFile();

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="censusList">The census list.</param>
        void PrintList( ICensus censusObj);

        /// <summary>
        /// Sorts the list.
        /// </summary>
        void SortList();

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        void Serialize(string path);
    }

    /// <summary>
    /// abstract class 
    /// </summary>
    /// <seealso cref="CensusAnalyser.ICensus" />
    public abstract class Census : ICensus
    {
        /// <summary>
        /// Path variable
        /// </summary>
        protected string Path;

        /// <summary>
        /// Delimiter variable
        /// </summary>
        protected string Delimiter;

        /// <summary>
        /// Header variable
        /// </summary>
        protected string Header;

        /// The census list
        /// </summary>
        protected List<ListNodeStateData> censusList = new List<ListNodeStateData>();

        protected List<ListNodeStateCode> CensusStateCodeList = new List<ListNodeStateCode>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Census"/> class.
        /// </summary>
        public Census()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Census"/> class.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        public Census(string Path, string Delimiter, string Header)
        {
            this.Path = Path;
            this.Delimiter = Delimiter;
            this.Header = Header;
        }

        /// <summary>
        /// Loads the CSV file.
        /// </summary>
        /// <returns> count of record </returns>
        public abstract string LoadCSVFile();

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetPath(string path){ this.Path = path; }

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public void SetDelimiter(string Delimiter) { this.Delimiter = Delimiter; }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public void SetHeader(string Header) { this.Header = Header; }

        /// <summary>
        /// Gets the census list.
        /// </summary>
        /// <returns></returns>
        public List<ListNodeStateData> GetCensusList()
        {
            return this.censusList;
        }

        /// <summary>
        /// Checks the delimiter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CensusAnalyserException"></exception>
        protected bool CheckDelimiter(string element)
        {
            if (this.Delimiter != null)
            {
                string[] arr = element.Split(this.Delimiter);
                if (arr.Length < 2)
                    throw new CensusAnalyserException(Enum_Exception.Incorrect_Delimiter_Exception.ToString());
            }
            return true;
        }

        /// <summary>
        /// Checks the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CensusAnalyserException"></exception>
        protected bool CheckHeader(string element)
        {
            if (this.Header != null)
                if (!element.Equals(this.Header))
                    throw new CensusAnalyserException(Enum_Exception.Incorrect_Header_Exception.ToString());
            return true;
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void PrintList(ICensus censusObj)
        {
            List<ListNodeStateData> listStateName;
            List<ListNodeStateCode> listStateCode;
            if (censusObj.GetType().ToString().Equals("CensusAnalyser.CSVStateCensus"))
            {
                listStateName = ((Census)censusObj).censusList;
                foreach (ListNodeStateData element in listStateName)
                {
                    Console.Write(element.StateName + " ");
                    Console.Write(element.Population + " ");
                    Console.Write(element.AreaInSqKm + " ");
                    Console.WriteLine(element.DensityPerSqKm + " ");
                }
            }
            else if (censusObj.GetType().ToString().Equals("CensusAnalyser.CSVStateCode"))
            {
                listStateCode = ((Census)censusObj).CensusStateCodeList;
                foreach (ListNodeStateCode element in listStateCode)
                {
                    Console.Write(element.SerialNo + " ");
                    Console.Write(element.StateName + " ");
                    Console.Write(element.TIN + " ");
                    Console.WriteLine(element.StateCode + " ");
                }
            }
           
        }

        /// <summary>
        /// Serializes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Serialize(string jsonpath)
        {
            string ListinString=null;
            if (jsonpath.Contains("StateName"))
                ListinString = JsonConvert.SerializeObject(this.censusList);
            else if(jsonpath.Contains("StateCode"))
                ListinString = JsonConvert.SerializeObject(this.CensusStateCodeList);
            File.WriteAllText(jsonpath, ListinString);
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public  void SortList()
        {
           // if(this.Path.Equals(@"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\Files\StateCode.csv"))
            if(this.GetType().ToString().Equals("CensusAnalyser.CSVStateCensus"))
                censusList.Sort();
            else if(this.GetType().ToString().Equals("CensusAnalyser.CSVStateCode")) 
                CensusStateCodeList.Sort();
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            StreamReader streamReaderObject = new StreamReader(path);
            string jsonstring = streamReaderObject.ReadToEnd();
            Console.WriteLine(jsonstring);
            return jsonstring;
        }

        /// <summary>
        /// Deserializes the state code using Generics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonstring">The jsonstring.</param>
        /// <returns></returns>
        public static T DeserializeStateCodeGenerics<T>(string jsonstring)
        {
            dynamic dlist = null;
            try
            {
                dlist =(T)JsonConvert.DeserializeObject<T>(jsonstring);
                return dlist;
            }
            catch (Exception e)
            {
                return dlist;
            }
        }

        /// <summary>
        ///  First and last item state code using generics.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string FirstAndLastItemStateCodeGenerics<T>(string path)
        {
            T list = DeserializeStateCodeGenerics<T>(ReadFile(path));
            int length = 0;
            dynamic dlist = list;
            int count = dlist.Count;
            dynamic ddata = null;
            foreach ( dynamic item in dlist)
            {
                if (length == 0 || length == count - 1)
                    ddata += item.StateName;
                length++;
            }
            return ddata;
        }


    }
}

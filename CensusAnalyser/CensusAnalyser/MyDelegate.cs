using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// class to create delegate
    /// </summary>
    public class MyDelegate
    {
        /// <summary>
        /// declare delgate
        /// </summary>
        /// <returns></returns>
        public delegate String CensusDelegates();

        /// <summary>
        /// declare delegate
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        /// <returns></returns>
        private delegate ICensusDAO ConstructCensusUsingBuilder(string type, string Path, string Delimiter = null, string Header = null);

        /// <summary>
        /// Delegate to serialize a object
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        public delegate void SerializeDelegate(string path);

        /// <summary>
        /// create and returns delegate object
        /// </summary>
        /// <returns> delgate object </returns>
        public static Delegate CreateCensusAnalyserLoadFileDelegate(ICensus CensusObj)
        {
            CensusDelegates delegateobject = new CensusDelegates(CensusObj.LoadCSVFile);
            return delegateobject;
        }

        /// <summary>
        /// Constructs the census using builder.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        /// <returns></returns>
        public static Delegate CreateCensusLoadFileDelegateUsingBuilder(string type, string Path, string Delimiter = null, string Header = null)
        {
            BuilderDirector.CreateBuilder();
            BuilderDirector.ConstructPath(Path);
            BuilderDirector.ConstructDelimiter(Delimiter);
            BuilderDirector.ConstructHeader(Header);
            ICensus _CensusObj = BuilderDirector.ConstructCensusUsingFactory(type);
            BuilderDirector.Construt(_CensusObj);
            Delegate CensusAnalyserDelegate = MyDelegate.CreateCensusAnalyserLoadFileDelegate(_CensusObj);
            return CensusAnalyserDelegate;
        }

        /// <summary>
        /// Creates the serialize delegate.
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        /// <returns></returns>
        public static Delegate CreateSerializeDelegate(ICensusDAO censusObj)
        {
            SerializeDelegate delegateobj = new SerializeDelegate(censusObj.SerializeDictionary);
            return delegateobj;
        }
    }

}

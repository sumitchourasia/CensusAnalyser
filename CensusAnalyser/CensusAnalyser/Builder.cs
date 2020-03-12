

namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Builder Interface
    /// </summary>
    public interface IBuilder
    {
         void SetPath(string Path);
         void SetDelimiter(string Delimiter);
         void SetHeader(string Header);
         ICensus Build(Census censusObj);
    }

    /// <summary>
    ///  Implemetation class for IBuilder interface
    /// </summary>
    /// <seealso cref="CensusAnalyser.IBuilder" />
    public class CensusBuilder  : IBuilder
    {
        private Census _CensusObj;
        private string _Path;
        private string _Delimiter;
        private string _Header;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusBuilder"/> class.
        /// </summary>
        public CensusBuilder()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusBuilder"/> class.
        /// </summary>
        /// <param name="CensusObj">The census object.</param>
        public CensusBuilder(Census CensusObj)
        {
            this._CensusObj = CensusObj;
        }

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="Path">The path.</param>
        public void SetPath(string Path)
        {
                this._Path = Path;
        }

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public void SetDelimiter(string Delimiter)
        {
            this._Delimiter = Delimiter;
        }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public void SetHeader(string Header)
        {
            this._Header = Header;
        }

        /// <summary>
        /// Builds the specified census object.
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        /// <returns></returns>
        public ICensus Build( Census censusObj)
        {
            censusObj.SetPath(_Path);
            censusObj.SetDelimiter(_Delimiter);
            censusObj.SetHeader(_Header);
            return censusObj;
        }
    }

    /// <summary>
    /// BuilderDirector class
    /// </summary>
    public class BuilderDirector
    {
        /// <summary>
        /// The builder object
        /// </summary>
        private static CensusBuilder builderObj;

        /// <summary>
        /// Constructs the path.
        /// </summary>
        /// <param name="Path">The path.</param>
        public static void ConstructPath(string Path)
        {
            builderObj.SetPath(Path);
        }

        /// <summary>
        /// Constructs the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public static void ConstructDelimiter(string Delimiter)
        {
            builderObj.SetDelimiter(Delimiter);
        }

        /// <summary>
        /// Constructs the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public static void ConstructHeader( string Header)
        {
            builderObj.SetHeader(Header);
        }

        /// <summary>
        /// Constructs the census using factory.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static ICensus ConstructCensusUsingFactory(string type)
        {
            ICensus censusObj = CensusFactory.create(type); ;
            return censusObj;
        }

        /// <summary>
        /// Creates the builder.
        /// </summary>
        /// <returns></returns>
        public static IBuilder CreateBuilder()
        {
            builderObj = new CensusBuilder();
            return builderObj;
        }

        /// <summary>
        /// Construts the specified buildobject.
        /// </summary>
        /// <param name="buildobject">The buildobject.</param>
        /// <param name="censusobject">The censusobject.</param>
        /// <returns></returns>
        public static ICensus Construt(IBuilder buildobject , ICensus censusobject)
        {
            buildobject.Build((Census)censusobject);
            return censusobject;
        }

        /// <summary>
        /// Constructs the census using builder.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="Path">The path.</param>
        /// <param name="Delimiter">The delimiter.</param>
        /// <param name="Header">The header.</param>
        /// <returns></returns>
        public static Delegate ConstructCensusUsingBuilder(string type , string Path , string Delimiter = null , string Header = null )
        {
            IBuilder builderObj = CreateBuilder();
            BuilderDirector.ConstructPath(Path);
            BuilderDirector.ConstructDelimiter(Delimiter);
            BuilderDirector.ConstructHeader(Header);
            ICensus censusObj = ConstructCensusUsingFactory(type);
            Construt(builderObj, censusObj);
            Delegate CensusAnalyserDelegate = MyDelegate.CreateCensusAnalyserDelegate(censusObj);
            return CensusAnalyserDelegate;
        }
    }
}

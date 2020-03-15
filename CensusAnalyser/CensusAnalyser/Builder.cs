

namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Builder Interface
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="Path">The path.</param>
        void SetPath(string Path);

        /// <summary>
        /// Sets the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        void SetDelimiter(string Delimiter);

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        void SetHeader(string Header);

        /// <summary>
        /// Builds the specified census object.
        /// </summary>
        /// <param name="censusObj">The census object.</param>
        /// <returns></returns>
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
        private static ICensus _CensusObj;

        /// <summary>
        /// The builder object
        /// </summary>
        private static CensusBuilder _BuilderObj;

        /// <summary>
        /// Constructs the path.
        /// </summary>
        /// <param name="Path">The path.</param>
        public static void ConstructPath(string Path)
        {
            _BuilderObj.SetPath(Path);
        }

        /// <summary>
        /// Constructs the delimiter.
        /// </summary>
        /// <param name="Delimiter">The delimiter.</param>
        public static void ConstructDelimiter(string Delimiter)
        {
            _BuilderObj.SetDelimiter(Delimiter);
        }

        /// <summary>
        /// Constructs the header.
        /// </summary>
        /// <param name="Header">The header.</param>
        public static void ConstructHeader( string Header)
        {
            _BuilderObj.SetHeader(Header);
        }

        /// <summary>
        /// Gets the census.
        /// </summary>
        /// <returns></returns>
        public static ICensus GetCensus()
        {
                if (_CensusObj == null)
                    throw new CSVBuilderException(Enum_Exception.NULL_CSVException.ToString());
                return _CensusObj;
        }

        /// <summary>
        /// Constructs the census using factory.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static ICensus ConstructCensusUsingFactory(string type)
        {
            _CensusObj = CensusFactory.create(type); ;
            return _CensusObj;
        }

        /// <summary>
        /// Creates the builder.
        /// </summary>
        /// <returns></returns>
        public static void CreateBuilder()
        {
            _BuilderObj = new CensusBuilder();
        }

        /// <summary>
        /// Construts the specified buildobject.
        /// </summary>
        /// <param name="buildobject">The buildobject.</param>
        /// <param name="censusobject">The censusobject.</param>
        /// <returns></returns>
        public static void Construt(ICensus censusobject)
        {
            _BuilderObj.Build((Census)censusobject);
        }
    }
}

using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeadeStateCodeFilePath = @"D:\Practice Projects\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
    }
}
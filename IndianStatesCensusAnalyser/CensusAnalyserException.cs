﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }

        public ExceptionType eType;

        public CensusAnalyserException(string message, ExceptionType eType) : base (message)
        {
            this.eType = eType;
        }

    }
}

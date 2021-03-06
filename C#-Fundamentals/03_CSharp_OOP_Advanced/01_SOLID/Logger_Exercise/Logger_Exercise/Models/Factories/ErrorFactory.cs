﻿using System;
using System.Globalization;
using Logger_Exercise.Models.Contracts;

namespace Logger_Exercise.Models.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string messege)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString,DateFormat,CultureInfo.InvariantCulture);

            
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);
            IError error = new Error(dateTime, errorLevel, messege); 

            return error;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", ae);
            }
        }
    }
}

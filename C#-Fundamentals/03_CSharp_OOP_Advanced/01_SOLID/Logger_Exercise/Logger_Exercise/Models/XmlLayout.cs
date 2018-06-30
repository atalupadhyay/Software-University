﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Logger_Exercise.Models.Contracts;

namespace Logger_Exercise.Models
{
    public class XmlLayout:ILayout
    {
        private const string DateFormat = "HH:mm:ss dd-MMM-yyyy";

        private string Format =
            "<log>" + Environment.NewLine +
               "\t<date>{0}</date>" + Environment.NewLine +
               "\t<level>{1}</level>" + Environment.NewLine +
               "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";
      

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Messege.ToString());

            return formattedError;
        }
    }
}

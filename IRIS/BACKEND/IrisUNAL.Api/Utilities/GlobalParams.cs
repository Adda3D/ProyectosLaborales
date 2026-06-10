using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Utilities
{
    public static class GlobalParams
    {
        public static string usuariocontroller { get; set; }

        public static NumberFormatInfo FormatoNumero
        {
            get
            {
                NumberFormatInfo valores = new NumberFormatInfo();
                valores.NumberDecimalSeparator = ".";
                valores.NumberGroupSeparator = ",";
                valores.NumberDecimalDigits = 0;

                return valores;
            }
        }

        public static NumberFormatInfo FormatoNumeroDecimal
        {
            get
            {
                NumberFormatInfo valores = new NumberFormatInfo();
                valores.NumberDecimalSeparator = ".";
                valores.NumberGroupSeparator = ",";
                valores.NumberDecimalDigits = 2;

                return valores;
            }
        }

    }
}
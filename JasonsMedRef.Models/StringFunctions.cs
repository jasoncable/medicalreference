using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models
{
    public static class StringFunctions
    {
        // https://phpa.health.maryland.gov/OIDEOR/IMMUN/Shared%20Documents/Handout%203%20-%20NDC%20conversion%20to%2011%20digits.pdf
        public static string ConvertToNdc11(string ndc)
        {
            if (ndc.Length == 9)
            {
                string[] split = ndc.Split('-');
                return split[0].PadLeft(5, '0') + "-" +
                       split[1].PadLeft(4, '0');
            }
            if (ndc.Length == 11)
            {
                return ndc.Substring(0, 5) + "-" +
                       ndc.Substring(5, 4) + "-" +
                       ndc.Substring(9, 2);

            }
            if (ndc.Length == 12)
            {
                string[] split = ndc.Split('-');
                return split[0].PadLeft(5, '0') + "-" +
                       split[1].PadLeft(4, '0') + "-" +
                       split[2].PadLeft(2, '0');
            }
            else
            {
                return ndc;
            }
        }


        public static string ConvertToNdc11NoDash(string ndc)
        {
            string[] split = ndc.Split('-');
            return split[0].PadLeft(5, '0') +
                   split[1].PadLeft(4, '0') +
                   split[2].PadLeft(2, '0');
        }
    }
}

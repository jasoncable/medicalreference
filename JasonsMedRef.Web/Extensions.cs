using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonsMedRef.Web
{
   public static class Extensions
    {
        public static string ToDisplayString(this double input)
        {
            return FloatToString(input);
        }

        public static string ToDisplayString(this float input)
        {
            return FloatToString(input);
        }

        public static string ToDisplayString(this decimal input)
        {
            if (input == 0m)
            {
                return "0.00";
            }
            else if (input < 0.25m)
            {
                input = Math.Round(input, 4);
                return input.ToString("0.0000");
            }
            else if (input < 0.5m)
            {
                input = Math.Round(input, 3);
                return input.ToString("0.000");
            }
            else if (input > 100m)
            {
                input = Math.Round(input, 0);
                return input.ToString("#,##0");
            }
            else
            {
                input = Math.Round(input, 2);
                return input.ToString("#,##0.00");
            }
        }

        public static string ToDisplayString(this long input)
        {
            return input.ToString("#,##0");
        }

        public static string ToDisplayString(this int input)
        {
            return input.ToString("#,##0");
        }

        public static string ToDisplayString(this double? input)
        {
            if (input == null)
                return "N/A";
            else
                return input.Value.ToDisplayString();
        }

        public static string ToDisplayString(this float? input)
        {
            if (input == null)
                return "N/A";
            else
                return input.Value.ToDisplayString();
        }

        public static string ToDisplayString(this decimal? input)
        {
            if (input == null)
                return "N/A";
            else
                return input.Value.ToDisplayString();
        }

        private static string FloatToString(double input)
        {
            if (input == 0d)
            {
                return "0.00";   
            }
            else if (input < 0.25)
            {
                input = Math.Round(input, 4);
                return input.ToString("0.0000");
            }
            else if (input < 0.5)
            {
                input = Math.Round(input, 3);
                return input.ToString("0.000");
            }
            else if (input > 100)
            {
                input = Math.Round(input, 0);
                return input.ToString("#,##0");
            }
            else
            {
                input = Math.Round(input, 2);
                return input.ToString("#,##0.00");
            }
        }

    }
}

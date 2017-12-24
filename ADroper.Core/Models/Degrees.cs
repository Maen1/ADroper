using System;
using System.Collections.Generic;
using System.Text;

namespace ADroper.Core.Models
{
    public class Degrees
    {
        public const string UNDERGRADUATE = "<";

        public const string POSTGRADUATE = ">=";

        public static List<string> GetAllDegrees()
        {
            return new List<string>() { nameof(UNDERGRADUATE), nameof(POSTGRADUATE) };
        }

        public static List<string> GetAllDegreesValues()
        {
            return new List<string>() { UNDERGRADUATE, POSTGRADUATE };
        }
    }

}

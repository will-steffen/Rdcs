using System;
using System.Collections.Generic;
using System.Linq;

namespace Rdcs.Utils
{
    public class EnumHelper
    {
        public static List<string> AsListString<EnumType>()
        {
            return Enum.GetNames(typeof(EnumType)).ToList();
        }

        public static List<int> AsListInt<EnumType>()
        {
            return ((int[])Enum.GetValues(typeof(EnumType))).ToList();
        }
    }
}

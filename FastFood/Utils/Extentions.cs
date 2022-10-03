using System;

namespace FastFoodDemo.Utils
{
    public static class NumberExtentions
    {
        public static decimal WithTwoDecimalPoints(this decimal val)
        {
            return decimal.Parse(val.ToString("0.00"));
        }

        public static decimal StringToDecimalWithTwoDecimalPoints(this string val)
        {
            decimal newdecimal = Convert.ToDecimal(val);
            return decimal.Parse(newdecimal.ToString("0.00"));
        }
    }

    public static class StringExtentions
    {
    }
}

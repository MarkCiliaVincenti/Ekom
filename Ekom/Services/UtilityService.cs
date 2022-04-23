using System;

namespace Ekom.Services
{
    internal class UtilityService
    {
        public static DateTime ConvertToDatetime(string value)
        {
            try
            {
                return new DateTime(Convert.ToInt64(value));
            }
            catch
            {
                return DateTime.ParseExact(value, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}

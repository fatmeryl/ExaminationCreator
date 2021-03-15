using System;
using System.Globalization;

namespace ExaminationCreator
{
    public static class SetStartDate
    {
        public static DateTime GetSelectedTimeAndDate()
        {
            var time = DateTime.Now.ToString("hh:mm:ss");
            var date = DateTime.Now.ToString("dd.MM.yyyy");
            var space = " ";
            DateTime myDate = DateTime.ParseExact($"{date}{space}{time}", "dd.MM.yyyy HH:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.None).ToUniversalTime();
            DateTime date2 = myDate.ToLocalTime();
            return DateTime.Now.ToLocalTime();
        }
    }
}

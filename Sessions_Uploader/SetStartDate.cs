using System;
using System.Globalization;

namespace ExaminationCreator
{
    public static class SetStartDate
    {
        public static DateTime GetSelectedTimeAndDate(string picketDate)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            var date = picketDate;
            var space = " ";
            DateTime myDate = DateTime.ParseExact($"{date}{space}{time}", "dd.MM.yyyy HH:mm:ss",
                CultureInfo.CurrentCulture, DateTimeStyles.None);
            var test = DateTime.Now.ToLocalTime();
            return DateTime.Now.ToLocalTime();
        }
    }
}

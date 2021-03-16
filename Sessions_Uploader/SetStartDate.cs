using System;
using System.Globalization;

namespace ExaminationCreator
{
    public static class SetStartDate
    {
        public static DateTime GetSelectedTimeAndDate(string picketDate)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            DateTime myDate = DateTime.ParseExact($"{picketDate} {time}", "dd.MM.yyyy HH:mm:ss",
                CultureInfo.CurrentCulture, DateTimeStyles.None);
            return myDate;
            //var test = DateTime.Now.ToLocalTime();
            //return DateTime.Now.ToLocalTime();
        }
    }
}

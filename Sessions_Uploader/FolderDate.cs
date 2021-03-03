using System;
using System.Text.RegularExpressions;

namespace ExaminationCreator
{
    class FolderDate
    {
        public string Folderdate { get; }

        public FolderDate(string folderdate)
        {
            string pattern = (@"[0-9]{14}_[A-Z][0-9]{25}");
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(folderdate))
            {
                Folderdate = folderdate;
            }
            else
            {
                Folderdate = "20180629121212_P7057940403073537057940403";
            }
        }

        public string GetDate()
        {
            return SessionUtility.GetDateStringFromSessionID(Folderdate);
        }

        public string ExaminationIdWithoutDate()
        {
            if (string.IsNullOrWhiteSpace(Folderdate))
            {
                throw new Exception("Invalid session ID");
            }

            return Folderdate.Substring(14);
        }
    }
}

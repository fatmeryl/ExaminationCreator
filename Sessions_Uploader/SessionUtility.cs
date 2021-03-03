using System;

namespace ExaminationCreator
{
    public static class SessionUtility
    {
        public static string GetDateStringFromSessionID(string sessionID)
        {
            if (string.IsNullOrWhiteSpace(sessionID))
            {
                throw new Exception("Invalid session ID");
            }

            return sessionID.Substring(0, 14);
        }
    }
}

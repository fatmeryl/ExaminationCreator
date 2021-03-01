using System;

namespace Sessions_Uploader
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

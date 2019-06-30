using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessions_Uploader
{
    public class SessionId
    {
        public string SessionID { get; }

        public SessionId(string sessionId)
        {
            SessionID = sessionId;
        }

        public string GetDate()
        {
            if (string.IsNullOrWhiteSpace(SessionID))
            {
                throw new Exception ("Invalid session ID");
            }

            return SessionID.Substring(0, 14);
        }

        public string ExaminationIdWithoutDate()
        {
            if (string.IsNullOrWhiteSpace(SessionID))
            {
                throw new Exception("Invalid session ID");
            }

            return SessionID.Substring(14);
        }
    }
}

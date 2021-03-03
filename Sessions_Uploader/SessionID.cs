namespace ExaminationCreator
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
            return SessionUtility.GetDateStringFromSessionID(SessionID);
        }
    }
}

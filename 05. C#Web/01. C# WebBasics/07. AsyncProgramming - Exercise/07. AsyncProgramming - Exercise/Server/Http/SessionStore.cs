using System.Collections.Concurrent;

public static class SessionStore
{
    public const string SessionCookieKey = "MY_SID";
    public const string CurrentUserSessionKey = "^%CurrentUser_Session_Key%^";

    private static readonly ConcurrentDictionary<string, HttpSession> sessions = 
                                 new ConcurrentDictionary<string, HttpSession>();

    public static HttpSession Get(string id)
                 => sessions.GetOrAdd(id, _ => new HttpSession(id));
    

}
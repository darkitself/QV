using System.Collections.Generic;

namespace QV.Infrastructure
{
    public class AppData
    {
        public User CurrentUser;
        public Dictionary<long, UserCard> UserCards;
        public Dictionary<long, AlienCard> AliensCards;
    }
}

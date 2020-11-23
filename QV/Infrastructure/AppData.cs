using System;
using System.Collections.Generic;
using System.Text;

namespace QV.Infrastructure
{
    public class AppData
    {
        public User CurrentUser;
        public Dictionary<long, UserCard> UserCards;
        public Dictionary<long, AlienCard> AliensCards;
    }
}

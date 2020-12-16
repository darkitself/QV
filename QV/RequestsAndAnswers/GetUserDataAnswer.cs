using QV.Infrastructure;
using System.Collections.Generic;

namespace QV.RequestsAndAnswers
{
    public class GetUserDataAnswer
    {
        public UserData Data { get; set; }
        public UserData Alt_Data { get; set; }
        public List<UserCard> User_Cards { get; set; }
        public List<AlienCard> Alien_Cards { get; set; }
    }
}

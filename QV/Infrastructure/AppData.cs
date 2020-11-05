using System;
using System.Collections.Generic;
using System.Text;

namespace QV.Infrastructure
{
    public class AppData
    {
        public User CurrentUser;
        public Dictionary<string, BC> UserBCs;
        public Dictionary<string, BC> AliensBCs;
    }
}

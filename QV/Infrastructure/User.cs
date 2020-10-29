using System;
using System.Collections.Generic;
using System.Text;

namespace QV.Infrastructure
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public UserData Data { get; set; }
    }
}

using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class UpdateUserDataRequest
    {
        public long UserID { get; set; }
        public UserData Data { get; set; }
    }
}

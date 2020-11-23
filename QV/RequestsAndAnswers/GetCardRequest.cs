using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class GetCardRequest
    {
        public long UserID { get; set; }
        public long CardID { get; set; }
    }
}

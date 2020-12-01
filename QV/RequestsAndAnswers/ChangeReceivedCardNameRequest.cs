using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class ChangeReceivedCardNameRequest
    {
        public long User_ID { get; set; }
        public long Card_ID { get; set; }
        public string Card_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class DeleteAlienCardRequest
    {
        public long User_ID { get; set; }
        public long Card_ID { get; set; }
    }
}

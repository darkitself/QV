using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class ChangeUserCardNameRequest
    {
        public long ID { get; set; }
        public string Card_Name { get; set; }
    }
}

using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class GetCardAnswer
    {
        public bool Result { get; set; }
        public AlienCard Card { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QV.RequestsAndAnswers
{
    public class CreateCardRequest
    {
        public long User_ID { get; set; }
        public string Card_Name { get; set; }
        public bool Alt_Data { get; set; }
        public bool Surname { get; set; }
        public bool Name { get; set; }
        public bool Patronymic { get; set; }
        public bool Image { get; set; }
        public bool Email { get; set; }
        public bool Phone_Number { get; set; }
        public bool Telegram { get; set; }
        public bool VK { get; set; }
        public bool Facebook { get; set; }
        public bool Instagram { get; set; }
        public bool Info { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QV.Infrastructure
{
    public class AlienCard
    {
        public long ID { get; set; }
        public string Card_Name { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Telegram { get; set; }
        public string VK { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Info { get; set; }
        public byte[] Image { get; set; }
        public string Image_Ext { get; set; }
        public string FullName => $"{Name} {Surname} {Patronymic}";
    }
}

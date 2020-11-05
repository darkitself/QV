using System;
using System.Collections.Generic;
using System.Text;

namespace QV.Infrastructure
{
    public class DataFlags
    {
        public bool Surname { get; set; } = false;
        public bool Name { get; set; } = false;
        public bool MiddleName { get; set; } = false;
        public bool TelephoneNumber { get; set; } = false;
        public bool Email { get; set; } = false;
        public bool VKLink { get; set; } = false;
        public bool FaceBookLink { get; set; } = false;

        public DataFlags()
        {
        }

        public DataFlags(UserData data)
        {
            foreach (var p in data.GetType().GetProperties())
                this.GetType().GetProperty(p.Name).SetValue(this, (string)p.GetValue(data) != null && (string)p.GetValue(data) != "");
        }
    }
}

namespace QV.Infrastructure
{
    public class DataFlags
    {
        public bool Surname { get; set; }
        public bool Name { get; set; }
        public bool MiddleName { get; set; }
        public bool TelephoneNumber { get; set; }
        public bool Email { get; set; }
        public bool VKLink { get; set; }
        public bool FaceBookLink { get; set; }

        public DataFlags()
        {
        }

        public DataFlags(UserData data)
        {
            foreach (var p in data.GetType().GetProperties())
                GetType().GetProperty(p.Name)
                         ?.SetValue(this,
                                    (string) p.GetValue(data) != null &&
                                    (string) p.GetValue(data) != "");
        }
    }
}
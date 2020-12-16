namespace QV.Infrastructure
{
    public class User
    {
        public long ID { get; set; }
        public UserData MainData { get; set; }
        public UserData AltData { get; set; }
    }
}

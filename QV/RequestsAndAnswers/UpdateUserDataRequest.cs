namespace QV.RequestsAndAnswers
{
    public class UpdateUserDataRequest
    {
        public long User_ID { get; set; }
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
    }
}

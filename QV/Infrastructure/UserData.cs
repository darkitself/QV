

namespace QV.Infrastructure
{
    public class UserData
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string VKLink { get; set; }
        public string FaceBookLink { get; set; }
        public string FullName => $"{Surname} {Name} {MiddleName}";
        public string VkReference => $"https://vk.com/{VKLink}";
        public string FacebookReference => $"https://ru-ru.facebook.com/{FaceBookLink}";
    }
}
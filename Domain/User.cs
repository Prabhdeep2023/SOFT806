namespace Database
{
    public class User
    {
        public Guid ID { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

namespace rest{
    public class CreateUserDto{
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public long birthDate { get; set; }
    }
}
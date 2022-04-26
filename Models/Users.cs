namespace Chemical_Management.Models
{
    public enum UserType { Admin, Standard }
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public UserType UserType { get; set; }
    }
}

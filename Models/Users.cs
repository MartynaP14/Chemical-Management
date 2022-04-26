using System.Security.Claims;

namespace Chemical_Management.Models
{
    public enum UserType { Admin, Standard }
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string password;
        public string Password { get { return password; } set { password = value; } }
        public UserType UserType { get; set; }
       
    }
}

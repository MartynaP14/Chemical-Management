using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public enum UserType { Admin, Standard }
    public class Users
    {
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        private string password;
        public string Password { get { return password; } set { password = value; } }

        [Display(Name = "User Type")]
        public UserType UserType { get; set; }
       
    }
}

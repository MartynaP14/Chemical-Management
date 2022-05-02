using Chemical_Management.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Chemical_Management.Controllers
{
    public class HomeController : Controller
    {
        /*private static List<Users> _AppUsers //will move to db soon
            = new List<Users>() {
            new Users { UserName = "Johnny", Password = "EAD2022", Id = 1, UserType = UserType.Admin},
            new Users { UserName = "Martyna", Password = "MARTYNA", Id = 2, UserType = UserType.Admin},
            new Users { UserName = "StandardUser", Password = "TestUser", Id = 3, UserType = UserType.Standard},
            };   */ 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult UserLogin()
        {
            return View();
        }
        /*
        [HttpGet("Login")] 
        public IActionResult Login(string returnURL)
        {
            ViewData["ReturnURL"] = returnURL; //returns login page 
            return View();
        }

        [HttpPost("login")] //posts login data for cookie based auth
        public async Task<IActionResult> Validate(string username, string password, string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;
            bool enter = _AppUsers.Where(x => x.UserName == username && x.Password == password).Any();
            if(enter == true)
            {
                //ViewData["ReturnUrl"] = returnURL;
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));  
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnURL);
            }
            TempData["Error"] = "Error: Username or password is incorrect";
            return View("login"); //returns user to login if password/username is not correct
        }

        [Authorize] //needs auth as you cannot logout if you haven't logged in
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
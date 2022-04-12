using Microsoft.AspNetCore.Mvc;
using Chemical_Management.Models;

namespace Chemical_Management.Controllers
{
    public class UserController : Controller
    {
        private static List<LabAnalyst> Users = new List<LabAnalyst>()
            {
            new LabAnalyst{ Name = "John Sheehan", Permissions = Permissions.Admin, UserID ="ADM-001"},
            new LabAnalyst { Name = "Peter Parker", Permissions= Permissions.Basic, UserID ="BSC-001"},
            new LabAnalyst { Name= "Tony Stark", Permissions = Permissions.Admin, UserID="ADM-002"}
            };

        //GET ALL USERS (RAZOR VIEW LIST)
        [HttpGet]
        public ActionResult DisplayUsers()
        {
            return View(Users);
        }

        //GET User-Create
        public ActionResult Create()
        {
            return View();
        }

        //Post User-Create
        [HttpPost]
        public ActionResult Create([Bind(include:"Name, Permission, UserID")]LabAnalyst labAnalyst)
        {
            Users.Add(labAnalyst);
            //return RedirectToAction("Index");
            return View(labAnalyst);
        }
    }
}

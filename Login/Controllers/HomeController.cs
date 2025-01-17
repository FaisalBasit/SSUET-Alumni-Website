using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext context;
        public HomeController(MyDbContext context)
        {
            this.context = context;
        }



      
       
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Index");
             
                
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserTbl user)
        {
            var myUser = context.UserTbls.FirstOrDefault(x => x.RollNum == user.RollNum && x.Password == user.Password);
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.RollNum);
                return RedirectToAction("Index"); // Redirect to the static HTML file
            }
            else
            {
                ViewBag.Message = "Login Failed...";
            }
            return View();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserTbl user)
        {
            if(ModelState.IsValid)
            {
                await context.UserTbls.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult AlumniGroup()
        {

            return View();
        }
        /*public async Task<IActionResult> AlumniGroup()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
                return RedirectToAction("Login");

            var groups = await context.AlumniGroups.ToListAsync();
            return View(groups);
        }*/
        [HttpPost]
        public IActionResult JoinGroup(int groupId)
        {
            var userRoll = HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userRoll))
            {
                return RedirectToAction("Login");
            }

            var myUser = context.UserTbls.FirstOrDefault(u => u.RollNum == userRoll);
            if (myUser == null)
            {
                return BadRequest("User not found.");
            }

            var alreadyJoined = context.UserGroups.Any(ug => ug.UserRoll == userRoll && ug.GroupId == groupId);
            if (alreadyJoined)
            {
                // Set a message for already joined
                TempData[$"Message_{groupId}"] = "You have already joined this group.";
                return RedirectToAction("AlumniGroup");
            }

            var userGroup = new UserGroup
            {
                UserRoll = userRoll,  // Use RollNum for UserRoll
                GroupId = groupId
            };

            try
            {
                context.UserGroups.Add(userGroup);
                context.SaveChanges();
                
                TempData[$"Success_{groupId}"] = "You have successfully joined the group!";
                return RedirectToAction("AlumniGroup");

                return RedirectToAction("AlumniGroup"); // Redirect to the same page to show success message
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while joining the group.");
            }
        }





        /*public IActionResult GroupDetails(int groupId)
        {
            var group = context.AlumniGroups.FirstOrDefault(g => g.G_id == groupId); // Use 'G_id' instead of 'GroupId'
            if (group == null)
            {
                return NotFound();
            }

            return View(group);  // Pass the single AlumniGroup object
        }*/

        public IActionResult Events()
        {
            return View();
        }
        public IActionResult MySSUET()
        {
            return View();
        }
        public IActionResult NewAlumni()
        {
            return View();
        }
        public IActionResult Engage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
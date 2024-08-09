using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly myContext _context;
        private readonly IWebHostEnvironment _environment;
        public AdminController(myContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }



        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            {
                return View();
            }
            else
            {

            return RedirectToAction("Login");
            }
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string adminEmail , string adminPassword)
        {
           var row =  _context.tbl_admin.FirstOrDefault(a=>a.admin_email == adminEmail);
           if(row!=null && row.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "incorrect Username or password";
                return View();
            }
            
            
           
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }



        public IActionResult Profile()
        {
          var adminId = HttpContext.Session.GetString("admin_session");
          var row = _context.tbl_admin.Where(a=>a.admin_id==int.Parse(adminId)).ToList();
            return View(row);
        }


        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }


        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile admin_image, Admin admin)
        {
            string imagePath = Path.Combine(_environment.WebRootPath, "admin_image", admin_image.FileName);
            FileStream fs = new FileStream(imagePath,FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image=admin_image.FileName;
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }





    }
}

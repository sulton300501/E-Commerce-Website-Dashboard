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
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }

        public IActionResult fetchCustomer()
        {
            return View(_context.tbl_customer.ToList());
        }

        public IActionResult customerDetails(int id)
        {
            var customer = _context.tbl_customer.FirstOrDefault(c => c.customer_id == id);
            return View(customer);
        }


        public IActionResult updateCustomer(int id)
        {
            return View(_context.tbl_customer.Find(id));
        }

        [HttpPost]
        public IActionResult updateCustomer(Customer customer, IFormFile customer_image)
        {
            string imagePath = Path.Combine(_environment.WebRootPath, "customer_images", customer_image.FileName);
            FileStream fs = new FileStream(imagePath, FileMode.Create);
            customer_image.CopyTo(fs);
            customer.customer_image = customer_image.FileName;
            _context.tbl_customer.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }



        public IActionResult deletePermission(int id)
        {
            return View(_context.tbl_customer.FirstOrDefault(x=>x.customer_id==id));
        }


        public IActionResult deleteCustomer(int id)
        {
           var customer = _context.tbl_customer.Find(id);
            _context.tbl_customer.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }

        public IActionResult fetchGategory()
        {
            return View(_context.tbl_categories.ToList());
        }

        public IActionResult addCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addCategory(Category cat)
        {
            _context.tbl_categories.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchGategory");
        }

        public IActionResult updateCategory(int id)
        {
            var category = _context.tbl_categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult updateCategory(Category cat)
        {
            _context.tbl_categories.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchGategory");
        }

        public IActionResult deletePermissionCategory(int id)
        {
            
            return View(_context.tbl_categories.FirstOrDefault(c => c.category_id == id));
        }

        public IActionResult deleteCategory(int id)
        {
            var category = _context.tbl_categories.Find(id);
            _context.tbl_categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("fetchGategory");
        }


        public IActionResult fetchProduct()
        {
            return View(_context.tbl_products.ToList());
        }


        public IActionResult addProduct()
        {
            List<Category> categories = _context.tbl_categories.ToList();
            ViewData["category"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product , IFormFile product_image)
        {
            string imageName = Path.GetFileName(product_image.FileName);
            string imagePath = Path.Combine(_environment.WebRootPath, "product_image", imageName);
            FileStream fs = new FileStream(imagePath, FileMode.Create);
            product_image.CopyTo(fs);
            product.product_image = imageName;


            _context.tbl_products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        // making instance of the connection we have to access the table categories in the database .
        private readonly AppDBContext _db;
        
        //just a normal constructor .
        public CategoryController(AppDBContext db ) {
            _db = db;
        }
        public IActionResult Index()
        {
            // here we make a ver to store the retrived data from the table . (old comment to ritreive a single table).
            // what we have here "viewModel" is a object from class called that long name 
            // it works actually as an constructor it initialize the Users and Categories with the table from 
            // the _db object here
            var viewModel = new UserCategoryViewModel
            {
                Users = _db.Users,
                Categories = _db.Categories
            };

              // dataResult here is list can be iterated using foreach until now i dont know how to use for loop damn .
            return View(viewModel);                                                                                                                
                                                                                                                                                
        }

        //GET
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(Category data)
        {
            //if (data.Name == null | data.DisplayOrder==null)
            //{
            //    return BadRequest("Enter both values");
            //}

            if(ModelState.IsValid)
            {
                _db.Categories.Add(data);
                _db.SaveChanges();

                return RedirectToAction("Index"); // if you want to redirect from other controller just add the controller name
                                                  // like this  =>  RedirectToAction("Index","ControllerName")
            }
            return View(data);

        }
    }

    public class UserCategoryViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}

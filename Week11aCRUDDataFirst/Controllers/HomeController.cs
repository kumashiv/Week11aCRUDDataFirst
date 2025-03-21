using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11aCRUDDataFirst.AppDbContext;
using Week11aCRUDDataFirst.Models;

namespace Week11aCRUDDataFirst.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly DataContext _db;      // To use this in various views
                                               // - In C#, a constructor is a special method used
                                               // for initializing new objects of a class.

        public HomeController(DataContext db)
        {
            _db = db;
        }



        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _db.Employee.Add(obj);      // adding to SQL query    //constructor part
            _db.SaveChanges();      // Saving
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployeeData()
        {
            var Emp = _db.Employee.ToList();
            return View(Emp);
        }

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var Emp = _db.Employee.FirstOrDefault( x=> x.id == id);     // matchind with database id
            _db.Employee.Remove(Emp);
            _db.SaveChanges();
            return RedirectToAction("GetEmployeeData");
        }

        [HttpGet]
        public IActionResult Update(int id)     //Getting edit-able page with id
        {
            var Emp = _db.Employee.FirstOrDefault(x => x.id == id);     // matching id with database id
            
            return View(Emp);
        }

        [HttpPost]
        public IActionResult Update(Employee obj)       // Saving edited page with information
        {
            _db.Employee.Update(obj);
            _db.SaveChanges();
            //return View();
            return RedirectToAction("GetEmployeeData");
        }

        public IActionResult Privacy()
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

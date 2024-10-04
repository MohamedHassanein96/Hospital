using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ApplicationDbContext _context= new ApplicationDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Index()
        {
            var doctors =_context.Doctors.ToList();
            return View(doctors);
        }
        public IActionResult Details(int id)
        {
            var doctors = _context.Doctors.Where(e => e.Id == id).FirstOrDefault();
            if (doctors != null) 
            {
                return View(doctors);
            }
            return RedirectToAction("NotFound");
            
            
        }
        public IActionResult NotFound()
        {
            return View();
        }

        //public IActionResult Book(int id)
        //{
        //    var doctors = _context.Doctors.Where(e => e.Id == id).FirstOrDefault();
        //    if (doctors != null)
        //    {
        //        return View(doctors);
        //    }
        //    return RedirectToAction("NotFound");
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

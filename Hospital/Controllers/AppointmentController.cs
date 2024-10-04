using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var data = applicationDbContext.Appointments.ToList();
            return View(data);
        }
        public IActionResult Create(int id)
        {
            var Doctors = applicationDbContext.Doctors.Where(e=>e.Id==id).FirstOrDefault();

            return View(Doctors);
        }
		public IActionResult SaveNew(Appointment appointment)
		{
            applicationDbContext.Add(appointment);
			applicationDbContext.SaveChanges();
            return RedirectToAction("CreationMessage");
		}
        public IActionResult CreationMessage(int id)
        {
			var Patient = applicationDbContext.Appointments.OrderByDescending(e=>e.Id).FirstOrDefault(); 
            return View(Patient);

        }
    }
}

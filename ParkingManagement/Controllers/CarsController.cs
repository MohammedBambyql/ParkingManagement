using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Models;
using ParkingManagement.Services;

namespace ParkingManagement.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext context;

        public CarsController( ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var cars = context.Cars.OrderByDescending(c => c.Id).ToList();
            return View(cars);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarCreate carCreate)
        {
            if(!ModelState.IsValid)
            {
                return View(carCreate);
            }

            Car car = new Car()
            {
                SlotNumber = carCreate.SlotNumber,
                VehicleNumber = carCreate.VehicleNumber,
                OwnerName = carCreate.OwnerName,
                ContactNumber = carCreate.ContactNumber,
                TimeIn = DateTime.Now,
                TimeOut = carCreate.TimeOut,
                Cost = carCreate.Cost,
            };

            context.Cars.Add(car);
            context.SaveChanges();

            return RedirectToAction("Index","Cars");
        }

        public IActionResult Edit(int id)
        {
            var car = context.Cars.Find(id);

            if(car == null)
            {
                return RedirectToAction("Index", "Cars");
            }

            var carCreate = new CarCreate()
            {
                SlotNumber = car.SlotNumber,
                VehicleNumber = car.VehicleNumber,
                OwnerName = car.OwnerName,
                ContactNumber = car.ContactNumber,
                TimeOut = car.TimeOut,
                Cost = car.Cost,
            };

            ViewData["CarId"] = car.Id;
            ViewData["TimeIn"] = car.TimeIn.ToString("MM/dd/yyyy");

            return View(carCreate);
        }
        [HttpPost]
        public IActionResult Edit(int id,CarCreate carCreate)
        {
            var car = context.Cars.Find(id);

            if(car == null)
            {
                return RedirectToAction("Index", "Cars");
            }

            if (!ModelState.IsValid)
            {
                ViewData["CarId"] = car.Id;
                ViewData["TimeIn"] = car.TimeIn.ToString("MM/dd/yyyy HH/mm");

                return View(carCreate);
            }

            car.SlotNumber = carCreate.SlotNumber;
            car.VehicleNumber = carCreate.VehicleNumber;
            car.OwnerName = carCreate.OwnerName;
            car.ContactNumber = carCreate.ContactNumber;
            car.TimeOut = carCreate.TimeOut;
            car.Cost = carCreate.Cost;

            context.SaveChanges();

            return RedirectToAction("Index", "Cars");

        }

        public IActionResult Delete(int id)
        {
            var car = context.Cars.Find(id);

            if(car == null)
            {
                return RedirectToAction("Index", "Cars");
            }

            context.Cars.Remove(car);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Cars");

        }


    }
}

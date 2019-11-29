using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppConsumer.Models;
using WebAppConsumer.Services;

namespace WebAppConsumer.Controllers
{
   public class CarController : Controller
   {
      public CarService CarService { get; }

      public CarController(CarService carService)
      {
         CarService = carService;
      }
      // GET: Car
      public async Task<ActionResult> Index()
      {
         return View(await CarService.ToListAsync());
      }

      // GET: Car/Details/5
      public async Task<ActionResult> Details(int id)
      {
         return View(await CarService.FindAsync(id));
      }

      // GET: Car/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: Car/Create
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create(Car car)
      {
         try
         {
            // TODO: Add insert logic here
            await CarService.AddAsync(car);
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: Car/Edit/5
      public async Task<ActionResult> Edit(int id)
      {
         return View(await CarService.FindAsync(id));
      }

      // POST: Car/Edit/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit(int id, Car car)
      {
         try
         {
            // TODO: Add update logic here
            if (id == car.Id)
            {
               await CarService.EditAsync(car);
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: Car/Delete/5
      public async Task<ActionResult> Delete(int id)
      {
         return View(await CarService.FindAsync(id));
      }

      // POST: Car/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Delete(int id, Car car)
      {
         try
         {
            // TODO: Add delete logic here
            await CarService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            IEnumerable<Dish> AllDishes = _context.Dishes.ToList();
            
            return View(AllDishes);
        }

        [HttpGet("dish/new")]
        public IActionResult DishForm()
        {
            return View();
        }

        [HttpPost("dish/submit")]
        public IActionResult NewDish(Dish fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();
                System.Console.WriteLine(fromForm.DishId);
                return RedirectToAction("DisplayDish", new { dishId = fromForm.DishId});
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpGet("dish/{dishId}")]
        public IActionResult DisplayDish(int dishId)
        {
            Dish toRender = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(toRender);
        }

        [HttpGet("dish/edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish toEdit = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (toEdit == null)
            {
                return RedirectToAction("Index");
            }
            return View("EditDish", toEdit);
        }

        [HttpPost("dish/update/{dishId}")]
        public IActionResult UpdateDish(int dishId, Dish fromForm)
        {
            if(ModelState.IsValid)
            {
                Dish inDb = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

                inDb.Name = fromForm.Name;
                inDb.Chef = fromForm.Chef;
                inDb.Tastiness = fromForm.Tastiness;
                inDb.Calories = fromForm.Calories;
                inDb.Description = fromForm.Description;
                inDb.UpdatedAt = DateTime.Now;

                _context.SaveChanges();
                return RedirectToAction("DisplayDish", new {dishId = dishId});
            }
            else
            {
                return EditDish(dishId);
            }
        }

        [HttpGet("dish/delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish toDelete = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            _context.Dishes.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

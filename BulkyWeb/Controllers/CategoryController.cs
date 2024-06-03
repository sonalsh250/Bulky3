using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        //we want an implementation of ApplicationDbContext, so in the constructor parameter, we will call ApplicationDbContext
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","Display Order cannot exactly match the name.");
            }

            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Find only works for the primary key which is id in this case
            Category? categoryFromDb = _db.Categories.Find(id);


            //FirstOrDefault can work for any value from the model
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Works when you need to do some calculation before FirstOrDefault
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb); 
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

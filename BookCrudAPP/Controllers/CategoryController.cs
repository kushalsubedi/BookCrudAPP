using BookCrudAPP.Data;
using BookCrudAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCrudAPP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _data;
      // Read Data from Database 
        public CategoryController(ApplicationDbContext data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objectCategoryList=_data.Categories;
            return View(objectCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            _data.Categories.Add(obj);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

using Food_Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Search.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly CategoryDB _catDb;

        public AdminController(CategoryDB catDb)
        {
            _catDb = catDb;
        }

        public IActionResult Categories()
        {
            var list = _catDb.GetCategories();
            return View(list);
        }

        [HttpPost]
        public IActionResult AddCategory(string category_name)
        {
            _catDb.AddCategory(category_name);
            return RedirectToAction("Categories");
        }
    }
}

using Food_Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Search.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelDB _db;
        private readonly IWebHostEnvironment _env;

        public HotelController(HotelDB db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel(Hotel model, IFormFile file)
        {
            string fileName = null;

            if (file != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                string path = Path.Combine(_env.WebRootPath, "images", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            model.hotel_image = "/images/" + fileName;
            model.owner_id = (int)HttpContext.Session.GetInt32("reg_id");

            _db.AddHotel(model);

            return RedirectToAction("AddHotel");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Food_Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Search.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private readonly ReviewDB _db;

        public ReviewController(ReviewDB db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult AddReview(int hotel_id, int rating, string comment)
        {
            int userId = (int)HttpContext.Session.GetInt32("reg_id");

            _db.AddReview(hotel_id, userId, rating, comment);

            return RedirectToAction("Index", "Home");
        }
    }
}

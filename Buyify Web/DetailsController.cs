using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buyify_Web.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Article? article = _context.Articles.FirstOrDefault(a => a.Id == id);

            if (article != null)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

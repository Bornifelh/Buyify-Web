using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Buyify_Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public IActionResult OnGet(int id)
        {
            Article = _context.Articles.FirstOrDefault(a => a.Id == id);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

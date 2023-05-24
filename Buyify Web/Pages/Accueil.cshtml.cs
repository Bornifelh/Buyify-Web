using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Buyify_Web.Pages
{
    public class AccueilModel : PageModel
    {
        private readonly Panier _panier;
        private readonly ApplicationDbContext _context;

        public List<Article> Articles { get; set; }

        public AccueilModel(ApplicationDbContext context)
        {
            _context = context;
            _panier = new Panier();
        }

        public void OnGet()
        {
            Articles = _context.Articles.ToList();
        }

        public IActionResult OnPostAjouterAuPanier(int id)
        {
            var article = GetArticleById(id);

            if (article != null)
            {
                var item = new PanierItem
                {
                    Id = article.Id,
                    NomProduit = article.Nom,
                    Prix = (double)article.Prix,
                    Quantite = 1
                };

                _panier.AjouterAuPanier(item);
            }

            return RedirectToPage("Panier");
        }

        private Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }
    }

    public class Panier
    {
        private readonly List<PanierItem> _items;

        public Panier()
        {
            _items = new List<PanierItem>();
        }

        public List<PanierItem> Items => _items;

        public void AjouterAuPanier(PanierItem item)
        {
            _items.Add(item);
        }
    }
}

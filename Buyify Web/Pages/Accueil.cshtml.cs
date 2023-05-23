using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Buyify_Web.Pages
{
    public class AccueilModel : PageModel
    {
        private readonly Panier _panier;
        private readonly ApplicationDbContext _context;

        public List<Article>? Articles { get; set; }

        public AccueilModel(ApplicationDbContext context)
        {
            _panier = new Panier();
            _context = context;
        }

        public void OnGet()
        {
            Articles = _context.Articles.ToList();
        }

        public IActionResult OnPostAjouterAuPanier(int Id)
        {
            Article? article = GetArticleById(Id: Id);

            if (article != null)
            {
                double prix = (double)article.Prix;
                var item = new PanierItem
                {
                    Id = article.Id,
                    NomProduit = article.Nom,
                    Prix = prix,
                    Quantite = 1
                };

                _panier.AjouterAuPanier(item);
            }

            return RedirectToPage("/Panier");
        }

        private static Article? GetArticleById(int Id)
        {
            using var context = new ApplicationDbContext();
            return context?.Articles.FirstOrDefault(a => a.Id == Id);
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
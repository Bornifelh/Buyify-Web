using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Buyify_Web.Pages
{
    public class AccueilModel : PageModel
    {
<<<<<<< HEAD
        private readonly ILogger<AccueilModel> _logger;
        private readonly Panier _panier;

        public List<Article> Articles { get; set; }

        public AccueilModel(ILogger<AccueilModel> logger)
        {
            _logger = logger;
            _panier = new Panier();
        }

        public void OnGet(ApplicationDbContext context)
        {
            Articles = context.Articles.ToList();
        }

        public IActionResult OnPostAjouterAuPanier(int id)
        {
            var article = GetArticleById(id);

            if (article != null)
            {
=======
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
>>>>>>> gestion-erreur-accueil
                var item = new PanierItem
                {
                    Id = article.Id,
                    NomProduit = article.Nom,
<<<<<<< HEAD
                    Prix = (double)article.Prix,
=======
                    Prix = prix,
>>>>>>> gestion-erreur-accueil
                    Quantite = 1
                };

                _panier.AjouterAuPanier(item);
            }

<<<<<<< HEAD
            return RedirectToPage("Panier");
        }

        private Article GetArticleById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Articles.FirstOrDefault(a => a.Id == id);
            }
        }
    }
}
=======
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
>>>>>>> gestion-erreur-accueil

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

        public List<Article> Articles { get; set; }

        public AccueilModel()
        {
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
            using (var context = new ApplicationDbContext())
            {
                return context.Articles.FirstOrDefault(a => a.Id == id);
            }
        }
    }
}

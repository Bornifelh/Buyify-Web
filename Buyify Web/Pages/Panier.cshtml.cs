using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Buyify_Web.Pages
{
    public class PanierModel : PageModel
    {
        private readonly Panier _panier;
        public List<PanierItem>? PanierItems { get; set; }

        public PanierModel()
        {
            _panier = new Panier();
        }

        public void OnGet()
        {
<<<<<<< HEAD
            PanierItems = _panier.PanierItems.ToList();
=======
            PanierItems = _panier.Items.ToList();
>>>>>>> gestion-erreur-accueil
        }
    }
}

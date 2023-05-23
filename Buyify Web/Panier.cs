namespace Buyify_Web
{
    public class Panier
    {
        public List<PanierItem> PanierItems { get; set; }

        public Panier()
        {
            PanierItems = new List<PanierItem>();
        }

        public void AjouterAuPanier(PanierItem item)
        {
            // Vérifier si l'élément existe déjà dans le panier
            var existingItem = PanierItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                // L'élément existe déjà, augmenter la quantité
                existingItem.Quantite += item.Quantite;
            }
            else
            {
                // Ajouter l'élément au panier
                PanierItems.Add(item);
            }
        }

        public void SupprimerDuPanier(int itemId)
        {
            // Supprimer l'élément du panier en fonction de l'ID
            var item = PanierItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                PanierItems.Remove(item);
            }
        }

        public decimal CalculerTotal()
        {
            // Calculer le total du panier en multipliant le prix par la quantité pour chaque élément
            decimal total = 0;
            foreach (var item in PanierItems)
            {
                total += (decimal)(item.Prix * item.Quantite);
            }
            return total;
        }
    }

}

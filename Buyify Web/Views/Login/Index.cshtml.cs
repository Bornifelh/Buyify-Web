using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Buyify_Web.Views.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }
        
        public IActionResult OnPost()
        {
            // Code à exécuter lorsque le formulaire est soumis (bouton Login cliqué)

            // Vérification des informations de connexion
            if (IsValidLogin(Email, Password))
            {
                // Rediriger vers la page d'accueil ou une autre page appropriée
                return RedirectToPage("/Index");
            }
            else
            {
                // Informations de connexion invalides, afficher un message d'erreur
                ModelState.AddModelError(string.Empty, "Invalid login credentials.");
                return Page();
            }
        }

        private static bool IsValidLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"« {nameof(email)} » ne peut pas être vide ou avoir la valeur Null.", nameof(email));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"« {nameof(password)} » ne peut pas être vide ou avoir la valeur Null.", nameof(password));
            }
            // Code de vérification des informations de connexion
            // Vous devez implémenter votre propre logique de vérification ici
            // Par exemple, vérifier si l'email et le mot de passe correspondent à un utilisateur enregistré dans votre base de données

            // Retourne true si les informations de connexion sont valides, sinon false
            return false;
        }
    }
}

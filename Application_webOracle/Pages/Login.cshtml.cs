using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_webOracle.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Vérifiez les informations d'identification
            if (Username == "scott" && Password == "tiger")
            {
                // Créez un cookie ou une session pour garder l'utilisateur connecté
                HttpContext.Session.SetString("IsAuthenticated", "true");

                // Redirigez vers la page d'accueil (Index)
                return RedirectToPage("Index");
            }
            else
            {
                ErrorMessage = "Nom d'utilisateur ou mot de passe incorrect.";
                return Page();
            }
        }
    }
}
